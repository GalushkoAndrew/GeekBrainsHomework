using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Cpu metric manager interface
    /// </summary>
    public interface ICpuManager : IMetricManager
    {
        /// <summary>
        /// Returns cpu metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        bool GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
