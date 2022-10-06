using System.Threading.Tasks;
using MassTransit;
using Restaurant.Messages;

namespace Restaurant.Kitchen.Consumers
{
    internal class KitchenTableBookedConsumer : IConsumer<ITableBooked>
    {
        private readonly Manager _manager;

        public KitchenTableBookedConsumer(Manager manager)
        {
            _manager = manager;
        }

        public Task Consume(ConsumeContext<ITableBooked> context)
        {
           var result = context.Message.Success;

           if (result)
               _manager.CheckKitchenReady(context.Message.OrderId, context.Message.PreOrder);
           
           return context.ConsumeCompleted;
        }
    }
}