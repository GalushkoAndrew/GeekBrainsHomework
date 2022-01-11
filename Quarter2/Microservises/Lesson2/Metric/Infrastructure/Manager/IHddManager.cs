using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Hdd metric manager interface
    /// </summary>
    public interface IHddManager : IMetricManager
    {
        /// <summary>
        /// Returns hdd metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        bool GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
