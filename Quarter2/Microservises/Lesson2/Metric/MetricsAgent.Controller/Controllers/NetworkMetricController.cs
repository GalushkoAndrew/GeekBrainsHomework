using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller
{
    /// <summary>
    /// Network metrics controller
    /// </summary>
    [Route("api/metrics/network")]
    public class NetworkMetricController : ControllerBase, IMetricsController
    {
        private readonly INetworkMetricsManager _manager;
        private readonly ILogger<NetworkMetricController> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricController(INetworkMetricsManager manager, ILogger<NetworkMetricController> logger)
        {
            _manager = manager;
            _logger = logger;
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
            try
            {
                _logger.LogInformation($"Input parameters: fromTime = {fromTime}, toTime = {toTime}");
                return Ok(_manager.GetMetricsFromAgent(fromTime, toTime));
            }
            catch (Exception ex)
            {
                try
                {
                    _logger.LogError(ex.Message);
                }
                catch (Exception)
                {
                }

                return BadRequest(ex.Message);
            }
        }
    }
}
