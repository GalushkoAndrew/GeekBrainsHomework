using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Hosting;
using Restaurant.Messages;

namespace Restaurant.Booking;

public class Worker : BackgroundService
{
    private readonly IBus _bus;

    public Worker(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var s = "Hello world";
        
        Console.WriteLine(s[^4] + s[3..5] + s[^8..^6]);
        

        Console.OutputEncoding = Encoding.UTF8;
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
            Console.WriteLine("Привет! Желаете забронировать столик?");
            var b = Guid.NewGuid();

            var dateTime = DateTime.Now;

            var topology = _bus.GetRabbitMqHostTopology();
            
            await _bus.Publish(new BookingRequest(b, Guid.NewGuid(), null, dateTime),
                stoppingToken);
        }
    }
}