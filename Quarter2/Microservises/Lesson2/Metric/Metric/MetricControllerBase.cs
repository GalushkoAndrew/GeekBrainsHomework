using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Base metrics controller
    /// </summary>
    [ApiController]
    public abstract class MetricControllerBase : ControllerBase, IMetricController
    {
        private readonly IMetricManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public MetricControllerBase(IMetricManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Returns agent's metrics filtered by dates
        /// </summary>
        /// <param name="agentId">agent</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return Ok(_manager.GetMetricsFromAgent(agentId, fromTime, toTime));
        }
    }
}
