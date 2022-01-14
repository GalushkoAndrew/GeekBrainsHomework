using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Network metric manager interface
    /// </summary>
    public interface INetworkMetricsManager : IMetricsManager
    {
        /// <summary>
        /// Returns network metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<NetworkMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
