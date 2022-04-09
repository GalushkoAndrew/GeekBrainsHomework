using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GeekBrains.Learn.TimeSheets
{
    /// <inheritdoc/>
    public class Program
    {
        /// <inheritdoc/>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <inheritdoc/>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
