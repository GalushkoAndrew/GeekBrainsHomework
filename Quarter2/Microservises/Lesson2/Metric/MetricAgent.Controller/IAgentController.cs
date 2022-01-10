using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.MetricAgent.Controller
{
    /// <summary>
    /// Agents controller interface
    /// </summary>
    public interface IAgentController
    {
        /// <summary>
        /// Returns list of agents
        /// </summary>
        IActionResult Get();
    }
}
