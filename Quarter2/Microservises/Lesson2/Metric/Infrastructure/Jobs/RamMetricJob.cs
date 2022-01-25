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
    public class RamMetricJob : IJob
    {
        private readonly IRepository<RamMetric> _repository;

        // счетчик для метрики Ram
        private readonly PerformanceCounter _ramCounter;

        /// <summary>
        /// ctor
        /// </summary>
        public RamMetricJob(IRepository<RamMetric> repository)
        {
            _repository = repository;
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        /// <inheritdoc/>
        public Task Execute(IJobExecutionContext context)
        {
            var ramAvaliable = Convert.ToInt32(_ramCounter.NextValue());

            _repository.Create(new RamMetric { Date = DateTime.Now, Value = ramAvaliable });

            return Task.CompletedTask;
        }
    }
}
