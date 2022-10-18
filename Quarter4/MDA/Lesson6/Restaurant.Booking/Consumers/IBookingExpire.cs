using System;

namespace Restaurant.Booking.Consumers
{
    public interface IBookingExpire
    {
        public Guid OrderId { get; }
    }

    public class BookingExpire : IBookingExpire
    {
        private readonly RestaurantBooking _instance;
        
        public BookingExpire(RestaurantBooking instance)
        {
            _instance = instance;
        }

        public Guid OrderId => _instance.OrderId;
    }
}