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
    public class HddMetricJob : IJob
    {
        private readonly IRepository<HddMetric> _repository;

        // счетчик для метрики Hdd
        private readonly PerformanceCounter _hddCounter;

        /// <summary>
        /// ctor
        /// </summary>
        public HddMetricJob(IRepository<HddMetric> repository)
        {
            _repository = repository;
            _hddCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
        }

        /// <inheritdoc/>
        public Task Execute(IJobExecutionContext context)
        {
            var hddUsage = Convert.ToInt32(_hddCounter.NextValue());

            _repository.Create(new HddMetric { Date = DateTime.Now, Value = hddUsage });

            return Task.CompletedTask;
        }
    }
}
