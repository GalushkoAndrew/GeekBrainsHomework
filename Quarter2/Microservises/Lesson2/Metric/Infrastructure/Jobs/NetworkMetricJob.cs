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
    public class NetworkMetricJob : IJob
    {
        //private readonly IRepository<NetworkMetric> _repository;

        //// счетчик для метрики Network
        //private readonly PerformanceCounter _networkCounter;

        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricJob(IRepository<NetworkMetric> repository)
        {
            //_repository = repository;
        }

        /// <inheritdoc/>
        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
