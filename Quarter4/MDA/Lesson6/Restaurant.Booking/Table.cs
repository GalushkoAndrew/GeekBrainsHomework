using System;

namespace Restaurant.Booking
{
    public class Table
    {
        public TableState State { get; private set; }
        public int SeatsCount { get; }
        public int Id { get; }

        public Table(int id)
        {
            Id = id; //в учебном примере просто присвоим id при вызове
            State = TableState.Free; // новый стол всегда свободен
            SeatsCount = Random.Next(2, 5); //пусть количество мест за каждым столом будет случайным, от 2х до 5ти
        }

        public bool SetState(TableState state)
        {
            lock (_lock)
            {
                if (state == State)
                    return false;
            
                State = state;
                return true;
            }
        }
        
        private readonly object _lock = new object();
        private static readonly Random Random = new ();
        
    }
}