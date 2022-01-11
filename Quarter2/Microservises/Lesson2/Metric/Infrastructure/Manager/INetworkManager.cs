using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Network metric manager interface
    /// </summary>
    public interface INetworkManager : IMetricManager
    {
        /// <summary>
        /// Returns network metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        bool GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
