using GeekBrains.Learn.Core.Infrastructure.Jobs;
using GeekBrains.Learn.Core.Infrastructure.Jobs.Service;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;
using GeekBrains.Learn.Core.Infrastructure.Repository;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

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
            service.AddTransient(typeof(IMetricsManager<,>), typeof(MetricsManager<,>));
            service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            service.AddTransient<IAgentRepository, AgentRepository>();
            service.AddTransient<IAgentManager, AgentManager>();
            service.AddTransient<IRegisterManager, RegisterManager>();

            service.AddSingleton<IJobFactory, SingletonJobFactory>();
            service.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            service.AddJobs();
            service.AddJobSchedule();

            return service;
        }

        /// <summary>
        /// Add jobs schedules
        /// </summary>
        public static IServiceCollection AddJobSchedule(this IServiceCollection service)
        {
            service.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд

            service.AddSingleton(new JobSchedule(
                jobType: typeof(RamMetricJob),
                cronExpression: "0/5 * * * * ?"));

            service.AddSingleton(new JobSchedule(
                jobType: typeof(DotnetMetricJob),
                cronExpression: "0/5 * * * * ?"));

            service.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricJob),
                cronExpression: "0/5 * * * * ?"));

            service.AddSingleton(new JobSchedule(
                jobType: typeof(NetworkMetricJob),
                cronExpression: "0/5 * * * * ?"));

            service.AddSingleton(new JobSchedule(
                jobType: typeof(AgentRegisterJob),
                cronExpression: "0/5 * * * * ?"));

            return service;
        }

        /// <summary>
        /// Add jobs
        /// </summary>
        public static IServiceCollection AddJobs(this IServiceCollection service)
        {
            service.AddSingleton<CpuMetricJob>();
            service.AddSingleton<RamMetricJob>();
            service.AddSingleton<DotnetMetricJob>();
            service.AddSingleton<HddMetricJob>();
            service.AddSingleton<NetworkMetricJob>();
            service.AddSingleton<AgentRegisterJob>();

            return service;
        }
    }
}
