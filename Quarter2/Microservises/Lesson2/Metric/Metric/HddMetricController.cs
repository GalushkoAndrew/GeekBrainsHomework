using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Hdd metrics controller
    /// </summary>
    [Route("api/metrics/hdd")]
    public class HddMetricController : ControllerBase, IMetricController
    {
        private readonly IHddManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public HddMetricController(IHddManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Returns metrics filtered by dates
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return Ok(_manager.GetMetricsFromAgent(fromTime, toTime));
        }
    }
}
