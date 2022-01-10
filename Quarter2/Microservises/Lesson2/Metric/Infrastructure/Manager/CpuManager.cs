using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Cpu metric manager
    /// </summary>
    public class CpuManager : ICpuManager
    {
        /// <inheritdoc/>
        public bool GetMetricsFromAgent(int agentId, DateTime fromTime, DateTime toTime)
        {
            return true;
        }
    }
}
