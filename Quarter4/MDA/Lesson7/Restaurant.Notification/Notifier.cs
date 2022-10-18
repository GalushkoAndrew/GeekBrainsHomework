using System;

namespace Restaurant.Notification;

public class Notifier
{
    public void Notify(Guid orderId, Guid clientId, string message)
    {
        Console.WriteLine($"[OrderID: {orderId}] Уважаемый клиент {clientId}! {message}");
    }
}