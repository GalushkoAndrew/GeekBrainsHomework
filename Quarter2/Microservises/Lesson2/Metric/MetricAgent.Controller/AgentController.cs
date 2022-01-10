using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.MetricAgent.Controller
{
    /// <summary>
    /// Agents controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase, IAgentController
    {
        /// <summary>
        /// Returns list of agents
        /// Stub: list empty
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
