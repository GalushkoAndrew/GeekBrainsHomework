using System.Threading.Tasks;
using Quartz;

namespace GeekBrains.Learn.Core.Infrastructure.Jobs
{
    /// <summary>
    /// Job
    /// </summary>
    public class NetworkMetricJob : IJob
    {
        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricJob()
        {
        }

        /// <inheritdoc/>
        public Task Execute(IJobExecutionContext context)
        {
            // ничего не собираю, не разобрался как собирать сетевые метрики
            return Task.CompletedTask;
        }
    }
}
