﻿using System;

namespace Restaurant.Messages
{
    public interface ITableBooked
    {
        public Guid OrderId { get; }

        public bool Success { get; }

        public DateTime CreationDate { get; }
    }
}