using System;

namespace Restaurant.Messages
{
    public interface IKitchenAccident
    {
        public Guid OrderId { get; }
        
        public Dish Dish { get; }
    }
}