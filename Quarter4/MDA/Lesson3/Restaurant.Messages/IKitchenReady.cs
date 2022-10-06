using System;

namespace Restaurant.Messages
{
    public interface IKitchenReady
    {
        public Guid OrderId { get; }
        
        public bool Ready { get; }
    }
}