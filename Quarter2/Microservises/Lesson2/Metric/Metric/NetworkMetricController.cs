using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Network metrics controller
    /// </summary>
    [Route("api/metrics/network")]
    public class NetworkMetricController : ControllerBase, IMetricController
    {
        private readonly INetworkManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricController(INetworkManager manager)
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
