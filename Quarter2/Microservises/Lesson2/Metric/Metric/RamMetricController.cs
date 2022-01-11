using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Ram metrics controller
    /// </summary>
    [Route("api/metrics/ram")]
    public class RamMetricController : ControllerBase, IMetricController
    {
        private readonly IRamManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public RamMetricController(IRamManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Returns metrics filtered by dates
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return Ok(_manager.GetMetricsFromAgent(fromTime, toTime));
        }
    }
}
