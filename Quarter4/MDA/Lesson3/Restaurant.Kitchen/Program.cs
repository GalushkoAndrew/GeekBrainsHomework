using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Kitchen.Consumers;
using System;

namespace Restaurant.Kitchen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<KitchenBookingRequestedConsumer>(
                            configurator =>
                            {
                                configurator.UseScheduledRedelivery(r =>
                                {
                                    r.Intervals(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(20),
                                        TimeSpan.FromSeconds(30));
                                });
                                configurator.UseMessageRetry(
                                    r =>
                                    {
                                        r.Incremental(3, TimeSpan.FromSeconds(1),
                                            TimeSpan.FromSeconds(2));
                                    }
                                );
                            })
                            .Endpoint(e =>
                            {
                                e.Temporary = true;
                            }); ;

                        x.AddConsumer<KitchenBookingRequestFaultConsumer>()
                            .Endpoint(e =>
                            {
                                e.Temporary = true;
                            });
                        x.AddDelayedMessageScheduler();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.UseDelayedMessageScheduler();
                            cfg.UseInMemoryOutbox();
                            cfg.ConfigureEndpoints(context);
                        });
                    });

                    services.AddSingleton<Manager>();
                });
    }
}