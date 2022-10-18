using System;
using System.Text;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Kitchen.Consumers;

namespace Restaurant.Kitchen;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<KitchenBookingRequestedConsumer>(
                        configurator =>
                        {
                            /*configurator.UseScheduledRedelivery(r =>
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
                            );*/
                        });

                    x.AddConsumer<KitchenBookingRequestFaultConsumer>();
                    x.AddDelayedMessageScheduler();

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.UseDelayedMessageScheduler();
                        cfg.UseInMemoryOutbox();
                        cfg.ConfigureEndpoints(context);
                    });
                });

                services.AddSingleton<Manager>();

                services.Configure<MassTransitHostOptions>(options =>
                {
                    options.WaitUntilStarted = true;
                    options.StartTimeout = TimeSpan.FromSeconds(30);
                    options.StopTimeout = TimeSpan.FromMinutes(1);
                });
            });
    }
}