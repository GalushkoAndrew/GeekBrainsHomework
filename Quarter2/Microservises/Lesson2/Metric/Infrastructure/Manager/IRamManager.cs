using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Ram metric manager interface
    /// </summary>
    public interface IRamManager : IMetricManager
    {
        /// <summary>
        /// Returns ram metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        bool GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
