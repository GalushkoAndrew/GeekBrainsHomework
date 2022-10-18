using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Restaurant.Messages;
using Restaurant.Messages.InMemoryDb;

namespace Restaurant.Booking.Consumers;

public class RestaurantBookingRequestConsumer : IConsumer<IBookingRequest>
{
    private readonly Restaurant _restaurant;
    private readonly IInMemoryRepository<BookingRequestModel> _repository;

    public RestaurantBookingRequestConsumer(Restaurant restaurant,
        IInMemoryRepository<BookingRequestModel> repository)
    {
        _restaurant = restaurant;
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<IBookingRequest> context)
    {
        var model = _repository.Get().FirstOrDefault(i => i.OrderId == context.Message.OrderId);
        
        if (model is not null && model.CheckMessageId(context.MessageId.ToString()))
        {
            Console.WriteLine(context.MessageId.ToString());
            Console.WriteLine("Second time");
            return;
        }
            
        var requestModel = new BookingRequestModel(context.Message.OrderId, context.Message.ClientId,
            context.Message.PreOrder, context.Message.CreationDate, context.MessageId.ToString());

        Console.WriteLine(context.MessageId.ToString());
        Console.WriteLine("First time");
        var resultModel = model?.Update(requestModel, context.MessageId.ToString()) ?? requestModel;
        
        _repository.AddOrUpdate(resultModel);
        var result = await _restaurant.BookFreeTableAsync(1);  
        await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, result ?? false));
    }
}