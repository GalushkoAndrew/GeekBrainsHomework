using RestaurantBooking.Enums;
using System;

namespace RestaurantBooking
{
    public class Table
    {
        public State State { get; private set; }
        public int SeatsCount { get; }
        public int Id { get; }
        public Table(int id)
        {
            Id = id;
            State = State.Free;
            SeatsCount = (new Random()).Next(2, 5);
        }

        public bool SetState(State state)
        {
            if (state == State)
            {
                return false;
            }
            State = state;
            return true;
        }
    }
}
