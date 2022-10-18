using System;
using MassTransit;
using Restaurant.Messages;

namespace Restaurant.Kitchen;

public class Manager
{

    public Manager()
    {
    }

    public bool CheckKitchenReady(Guid orderId, Dish? dish)
    {
        return true;
    }
}