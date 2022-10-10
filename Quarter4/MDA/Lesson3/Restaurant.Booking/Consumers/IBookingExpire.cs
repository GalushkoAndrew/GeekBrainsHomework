using System;

namespace Restaurant.Booking.Consumers
{
    public interface IBookingExpire
    {
        public Guid OrderId { get; }
    }
}