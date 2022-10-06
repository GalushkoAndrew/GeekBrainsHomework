using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Restaurant.Messages;

namespace Restaurant.Booking
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;
        private readonly Restaurant _restaurant;

        public Worker(IBus bus, Restaurant restaurant)
        {
            _bus = bus;
            _restaurant = restaurant;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {                
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(10000, stoppingToken);
                Console.WriteLine("Привет! Желаете забронировать столик?");
                var result = await _restaurant.BookFreeTableAsync(1);
                //забронируем с ответом по смс
                await _bus.Publish(new TableBooked(NewId.NextGuid(), NewId.NextGuid(), result ?? false),
                    context => context.Durable = false, stoppingToken);
            }
        }
    }
}