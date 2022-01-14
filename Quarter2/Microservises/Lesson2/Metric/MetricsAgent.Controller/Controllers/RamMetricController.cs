using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller
{
    /// <summary>
    /// Ram metrics controller
    /// </summary>
    [Route("api/metrics/ram")]
    public class RamMetricController : ControllerBase, IMetricsController
    {
        private readonly IRamMetricsManager _manager;
        private readonly ILogger<RamMetricController> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        public RamMetricController(IRamMetricsManager manager, ILogger<RamMetricController> logger)
        {
            _manager = manager;
            _logger = logger;
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
