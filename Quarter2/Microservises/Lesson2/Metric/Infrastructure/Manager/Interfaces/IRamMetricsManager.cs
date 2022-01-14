using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Ram metric manager interface
    /// </summary>
    public interface IRamMetricsManager : IMetricsManager
    {
        /// <summary>
        /// Returns ram metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<RamMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
