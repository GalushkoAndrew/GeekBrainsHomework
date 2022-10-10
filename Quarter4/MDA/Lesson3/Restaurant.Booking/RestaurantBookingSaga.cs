using System;
using MassTransit;
using Restaurant.Booking.Consumers;
using Restaurant.Messages;

namespace Restaurant.Booking
{
    public sealed class RestaurantBookingSaga : MassTransitStateMachine<RestaurantBooking>
    {
        public RestaurantBookingSaga()
        {
            InstanceState(x => x.CurrentState);

            Event(() => BookingRequested,
                x =>
                    x.CorrelateById(context => context.Message.OrderId)
                        .SelectId(context => context.Message.OrderId));
            
            Event(() => TableBooked,
                x =>
                    x.CorrelateById(context => context.Message.OrderId));

            Event(() => KitchenReady, 
                x =>
                    x.CorrelateById(context => context.Message.OrderId));

            CompositeEvent(() => BookingApproved, 
                x => x.ReadyEventStatus, KitchenReady, TableBooked);

            Event(() => BookingRequestFault,
                x => 
                    x.CorrelateById(m => m.Message.Message.OrderId));

            Schedule(() => BookingExpired,
                x => x.ExpirationId, x =>
            {
                x.Delay = TimeSpan.FromSeconds(5);
                x.Received = e => e.CorrelateById(context => context.Message.OrderId);
            });
            
            Initially(
                When(BookingRequested)
                    .Then(context =>
                    {
                        context.Saga.CorrelationId = context.Message.OrderId;
                        context.Saga.OrderId = context.Message.OrderId;
                        context.Saga.ClientId = context.Message.ClientId;
                        Console.WriteLine("Saga: " + context.Message.CreationDate);
                    })
                    .Schedule(BookingExpired, 
                        context => new BookingExpire (context.Saga),
                        context => TimeSpan.FromSeconds(1))
                    .TransitionTo(AwaitingBookingApproved)
            );

            During(AwaitingBookingApproved,
                When(BookingApproved)
                    .Unschedule(BookingExpired)
                    .Publish(context =>
                        (INotify) new Notify(context.Saga.OrderId,
                            context.Saga.ClientId,
                            $"Стол успешно забронирован"))
                    .Finalize(),

                When(BookingRequestFault)
                    .Then(context => Console.WriteLine($"Ошибочка вышла!"))
                    .Publish(context => (INotify) new Notify(context.Saga.OrderId,
                        context.Saga.ClientId,
                        $"Приносим извинения, стол забронировать не получилось."))
                    .Publish(context => (IBookingCancellation) 
                        new BookingCancellation(context.Message.Message.OrderId))
                    .Finalize(),
                
                When(BookingExpired.Received)
                    .Then(context => Console.WriteLine($"Отмена заказа {context.Saga.OrderId}"))
                    .Finalize()
            );

            SetCompletedWhenFinalized();
        }
        public State AwaitingBookingApproved { get; private set; }
        public Event<IBookingRequest> BookingRequested { get; private set; }
        public Event<ITableBooked> TableBooked { get; private set; }
        public Event<IKitchenReady> KitchenReady { get; private set; }
        
        public Event<Fault<IBookingRequest>> BookingRequestFault { get; private set; }

        public Schedule<RestaurantBooking, IBookingExpire> BookingExpired { get; private set; }
        public Event BookingApproved { get; private set;  }
    }
}