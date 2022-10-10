﻿using System;

namespace Restaurant.Messages
{
    public class KitchenReady : IKitchenReady
    {
        public KitchenReady(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; }
    }
}