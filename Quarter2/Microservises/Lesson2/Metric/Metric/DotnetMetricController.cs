using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Dotnet metrics controller
    /// </summary>
    [Route("api/metrics/dotnet")]
    public class DotnetMetricController : ControllerBase, IMetricController
    {
        private readonly IDotnetManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public DotnetMetricController(IDotnetManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Returns metrics filtered by dates
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            return Ok(_manager.GetMetricsFromAgent(fromTime, toTime));
        }
    }
}
