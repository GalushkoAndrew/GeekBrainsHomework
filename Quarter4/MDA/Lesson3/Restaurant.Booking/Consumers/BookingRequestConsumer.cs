using System;
using System.Threading.Tasks;
using MassTransit;
using Restaurant.Messages;

namespace Restaurant.Booking.Consumers
{
    public class RestaurantBookingRequestConsumer : IConsumer<IBookingRequest>
    {
        private readonly Restaurant _restaurant;

        public RestaurantBookingRequestConsumer(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }

        public async Task Consume(ConsumeContext<IBookingRequest> context)
        {
            Console.WriteLine($"[OrderId: {context.Message.OrderId}]");
            var result = await _restaurant.BookFreeTableAsync(1);
            var rnd = new Random().Next(1000, 10000);
            if (rnd > 8000)
            {
                throw new Exception("Возникла ошибка");
            }
            await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, result ?? false));
        }
    }
}