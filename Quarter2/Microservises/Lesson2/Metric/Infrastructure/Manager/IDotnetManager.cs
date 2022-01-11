using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Dotnet metric manager interface
    /// </summary>
    public interface IDotnetManager : IMetricManager
    {
        /// <summary>
        /// Returns dotnet metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        bool GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
