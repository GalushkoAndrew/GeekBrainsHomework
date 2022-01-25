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
    public class DotnetMetricJob : IJob
    {
        private readonly IRepository<DotnetMetric> _repository;

        // счетчик для метрики Dotnet
        private readonly PerformanceCounter _dotnetCounter;

        /// <summary>
        /// ctor
        /// </summary>
        public DotnetMetricJob(IRepository<DotnetMetric> repository)
        {
            _repository = repository;
            _dotnetCounter = new PerformanceCounter(".NET CLR Memory", "% Time in GC", "_Global_");
        }

        /// <inheritdoc/>
        public Task Execute(IJobExecutionContext context)
        {
            var dotnetUsageInPercents = Convert.ToInt32(_dotnetCounter.NextValue());

            _repository.Create(new DotnetMetric { Date = DateTime.Now, Value = dotnetUsageInPercents });

            return Task.CompletedTask;
        }
    }
}
