using System;

namespace Restaurant.Messages
{
    public class BookingCancellation : IBookingCancellation
    {
        public BookingCancellation(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; }
    }
}
