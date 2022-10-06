using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Restaurant.Booking
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.UsingRabbitMq((context,cfg) =>
                        {
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    //services.AddMassTransitHostedService(true);

                    services.AddTransient<Restaurant>();

                    services.AddHostedService<Worker>();
                });
    }
}