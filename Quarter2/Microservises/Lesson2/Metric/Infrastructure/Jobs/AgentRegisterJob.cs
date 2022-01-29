using System.Threading.Tasks;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;
using Quartz;

namespace GeekBrains.Learn.Core.Infrastructure.Jobs
{
    /// <summary>
    /// Job
    /// </summary>
    public class AgentRegisterJob : IJob
    {
        private readonly IRegisterManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public AgentRegisterJob(IRegisterManager manager)
        {
            _manager = manager;
        }

        /// <inheritdoc/>
        public Task Execute(IJobExecutionContext context)
        {
            _manager.Register();

            return Task.CompletedTask;
        }
    }
}
