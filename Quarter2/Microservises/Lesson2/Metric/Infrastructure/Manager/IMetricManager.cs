using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Metric manager interface
    /// </summary>
    public interface IMetricManager
    {
        /// <summary>
        /// Stab for getting metrics
        /// </summary>
        /// <param name="agentId">agent</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        bool GetMetricsFromAgent(int agentId, DateTime fromTime, DateTime toTime);
    }
}
