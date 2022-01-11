using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.Extensions.DependencyInjection;

namespace GeekBrains.Learn.Core.Infrastructure.DI
{
    /// <summary>
    /// Service collection extension methods
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds required services
        /// </summary>
        /// <param name="service">Service collection</param>
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddTransient<ICpuManager, CpuManager>();
            service.AddTransient<IDotnetManager, DotnetManager>();
            service.AddTransient<IHddManager, HddManager>();
            service.AddTransient<INetworkManager, NetworkManager>();
            service.AddTransient<IRamManager, RamManager>();
            return service;
        }
    }
}
