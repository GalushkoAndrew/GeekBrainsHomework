﻿using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.Infrastructure.Repository;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;
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
            service.AddTransient<ICpuMetricsManager, CpuMetricsManager>();
            service.AddTransient<IDotnetMetricsManager, DotnetMetricsManager>();
            service.AddTransient<IHddMetricsManager, HddMetricsManager>();
            service.AddTransient<INetworkMetricsManager, NetworkMetricsManager>();
            service.AddTransient<IRamMetricsManager, RamMetricsManager>();

            service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            return service;
        }
    }
}