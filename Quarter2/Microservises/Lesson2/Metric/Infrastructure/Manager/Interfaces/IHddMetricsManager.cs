using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Hdd metric manager interface
    /// </summary>
    public interface IHddMetricsManager : IMetricsManager
    {
        /// <summary>
        /// Returns hdd metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<HddMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
