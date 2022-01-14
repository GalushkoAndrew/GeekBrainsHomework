using System;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller
{
    /// <summary>
    /// Metric controller interface
    /// </summary>
    public interface IMetricsController
    {
        /// <summary>
        /// Returns agent's metrics filtered by dates
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        IActionResult GetMetricsFromAgent(DateTime fromTime, DateTime toTime);
    }
}
