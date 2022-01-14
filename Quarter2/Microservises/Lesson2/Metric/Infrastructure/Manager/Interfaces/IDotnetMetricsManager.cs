using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Dotnet metric manager interface
    /// </summary>
    public interface IDotnetMetricsManager : IMetricsManager
    {
        /// <summary>
        /// Returns dotnet metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<DotnetMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
