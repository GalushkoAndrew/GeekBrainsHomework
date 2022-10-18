using System;
using System.Text;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Notification.Consumers;

namespace Restaurant.Notification;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<NotifyConsumer>();

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.UseMessageRetry(r =>
                        {
                            r.Exponential(5,
                                TimeSpan.FromSeconds(1),
                                TimeSpan.FromSeconds(100),
                                TimeSpan.FromSeconds(5));
                            r.Ignore<StackOverflowException>();
                            r.Ignore<ArgumentNullException>(x => x.Message.Contains("Consumer"));
                        });


                        cfg.ConfigureEndpoints(context);
                    });
                });

                services.AddSingleton<Notifier>();
                services.Configure<MassTransitHostOptions>(options =>
                {
                    options.WaitUntilStarted = true;
                    options.StartTimeout = TimeSpan.FromSeconds(30);
                    options.StopTimeout = TimeSpan.FromMinutes(1);
                });
            });
    }
}