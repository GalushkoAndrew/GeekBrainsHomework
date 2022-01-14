using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricAgent.Controller
{
    /// <summary>
    /// Agent's manager controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsManagerController : ControllerBase, IMetricsManagerController
    {
        private readonly ILogger<MetricsManagerController> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        public MetricsManagerController(ILogger<MetricsManagerController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns list of agents
        /// Stub: list empty
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation($"Input parameters: no parameters");
            return Ok();
        }
    }
}
