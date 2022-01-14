using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller
{
    /// <summary>
    /// Hdd metrics controller
    /// </summary>
    [Route("api/metrics/hdd")]
    public class HddMetricController : ControllerBase, IMetricsController
    {
        private readonly IHddMetricsManager _manager;
        private readonly ILogger<HddMetricController> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        public HddMetricController(IHddMetricsManager manager, ILogger<HddMetricController> logger)
        {
            _manager = manager;
            _logger = logger;
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
