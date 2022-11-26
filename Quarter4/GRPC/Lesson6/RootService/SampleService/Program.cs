using Microsoft.AspNetCore.HttpLogging;
using NLog.Web;
using Polly;
using RootServiceNamespace;
using SampleService.Services.Client;

namespace SampleService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddHttpClient("RootServiceClient", client =>
            //{

            //});

            #region Configure Logging Services

            builder.Services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All | HttpLoggingFields.RequestQuery;
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
                logging.RequestHeaders.Add("Authorization");
                logging.RequestHeaders.Add("X-Real-IP");
                logging.RequestHeaders.Add("X-Forwarded-For");
            });

            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();

            }).UseNLog(new NLogAspNetCoreOptions() { RemoveLoggerFactoryFilter = true });

            #endregion

            builder.Services.AddHttpClient<IRootServiceClient, 
                SampleService.Services.Client.Impl.RootServiceClient>("RootServiceClient")
                .AddTransientHttpErrorPolicy(
                    configurePolicy => configurePolicy.WaitAndRetryAsync(retryCount: 3,
                    sleepDurationProvider: (attemptCount) => TimeSpan.FromSeconds(attemptCount*2),
                    onRetry : (response, sleepDuration, attemptNumber, context) => {
                        var logger = builder.Services.BuildServiceProvider().GetService<ILogger<Program>>();

                        logger.LogError(response.Exception != null ? response.Exception :
                            new Exception($"\n{response.Result.StatusCode}: {response.Result.RequestMessage}"),

                            $"(attempt: {attemptNumber}) RootServiceClient request exception.");

                    }));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseHttpLogging();

            app.MapControllers();

            app.Run();
        }
    }
}