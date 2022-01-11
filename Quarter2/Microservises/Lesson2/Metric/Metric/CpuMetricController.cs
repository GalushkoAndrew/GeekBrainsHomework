using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Cpu metrics controller
    /// </summary>
    [Route("api/metrics/cpu")]
    public class CpuMetricController : ControllerBase, IMetricController
    {
        private readonly ICpuManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public CpuMetricController(ICpuManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Returns metrics filtered by dates
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return Ok(_manager.GetMetricsFromAgent(fromTime, toTime));
        }
    }
}
