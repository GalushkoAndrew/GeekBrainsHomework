using System;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsManager.Controller
{
    /// <summary>
    /// Agent's manager controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class MetricsManagerController : ControllerBase
    {
        private readonly ILogger<MetricsManagerController> _logger;
        private readonly IAgentManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public MetricsManagerController(ILogger<MetricsManagerController> logger, IAgentManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        /// <summary>
        /// Returns list of agents
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                Log($"Input parameters: no parameters");
                return Ok(_manager.GetAll());
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Register agent
        /// </summary>
        /// <param name="uri">agent's uri</param>
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromQuery] string uri)
        {
            try
            {
                Log($"Input parameters: {uri}");
                _manager.Create(uri);
                return Ok();
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns agent's Cpu metrics filtered by dates
        /// </summary>
        /// <param name="agentId">agent id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("cpu/agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetCpuMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            try
            {
                Log($"Input parameters: agentId = {agentId}, fromTime = {fromTime}, toTime = {toTime}");
                return Ok(_manager.GetCpuMetric(agentId, fromTime, toTime));
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns agent's Dotnet metrics filtered by dates
        /// </summary>
        /// <param name="agentId">agent id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("dotnet/agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetDotnetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            try
            {
                Log($"Input parameters: agentId = {agentId}, fromTime = {fromTime}, toTime = {toTime}");
                return Ok(_manager.GetDotnetMetric(agentId, fromTime, toTime));
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns agent's Hdd metrics filtered by dates
        /// </summary>
        /// <param name="agentId">agent id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("hdd/agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetHddMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            try
            {
                Log($"Input parameters: agentId = {agentId}, fromTime = {fromTime}, toTime = {toTime}");
                return Ok(_manager.GetHddMetric(agentId, fromTime, toTime));
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns agent's Network metrics filtered by dates
        /// </summary>
        /// <param name="agentId">agent id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("network/agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetworkMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            try
            {
                Log($"Input parameters: agentId = {agentId}, fromTime = {fromTime}, toTime = {toTime}");
                return Ok(_manager.GetNetworkMetric(agentId, fromTime, toTime));
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns agent's Ram metrics filtered by dates
        /// </summary>
        /// <param name="agentId">agent id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("ram/agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetRamMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            try
            {
                Log($"Input parameters: agentId = {agentId}, fromTime = {fromTime}, toTime = {toTime}");
                return Ok(_manager.GetRamMetric(agentId, fromTime, toTime));
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        private void Log(string message, LogLevel logLevel = LogLevel.Information)
        {
            try
            {
                _logger.Log(logLevel, message);
            }
            catch (Exception)
            {
            }
        }
    }
}
