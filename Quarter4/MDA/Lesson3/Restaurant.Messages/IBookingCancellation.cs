using System;

namespace Restaurant.Messages
{
    public interface IBookingCancellation
    {
        public Guid OrderId { get; }
    }
}
