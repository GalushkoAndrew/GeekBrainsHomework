using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Messaging;
using Microsoft.Extensions.Hosting;

namespace Restaurant.Notification
{
    public class Worker : BackgroundService
    {
        private readonly Consumer _consumer;

        public Worker()
        {
            //важно чтобы имя очереди совпадало
            _consumer = new Consumer("BookingNotification", "localhost");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Receive((sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body); //декодируем
                Console.WriteLine(" [x] Received {0}", message);
            });
        }
    }
}