using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Cpu metric manager interface
    /// </summary>
    public interface ICpuMetricsManager : IMetricsManager
    {
        /// <summary>
        /// Returns cpu metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<CpuMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
