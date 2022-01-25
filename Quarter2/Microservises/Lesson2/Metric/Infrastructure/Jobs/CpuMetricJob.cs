using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;
using Quartz;

namespace GeekBrains.Learn.Core.Infrastructure.Jobs
{
    /// <summary>
    /// Job
    /// </summary>
    public class CpuMetricJob : IJob
    {
        private readonly IRepository<CpuMetric> _repository;

        // счетчик для метрики CPU
        private readonly PerformanceCounter _cpuCounter;

        /// <summary>
        /// ctor
        /// </summary>
        public CpuMetricJob(IRepository<CpuMetric> repository)
        {
            _repository = repository;
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        /// <inheritdoc/>
        public Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercents = Convert.ToInt32(_cpuCounter.NextValue());

            _repository.Create(new CpuMetric { Date = DateTime.Now, Value = cpuUsageInPercents });

            return Task.CompletedTask;
        }
    }
}
