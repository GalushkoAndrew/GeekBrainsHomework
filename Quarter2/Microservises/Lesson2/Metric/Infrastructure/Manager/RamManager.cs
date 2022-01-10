using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Ram metric manager
    /// </summary>
    public class RamManager : IRamManager
    {
        /// <inheritdoc/>
        public bool GetMetricsFromAgent(int agentId, DateTime fromTime, DateTime toTime)
        {
            return true;
        }
    }
}
