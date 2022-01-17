using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.MetricsManager.Controller
{
    /// <summary>
    /// Agents controller interface
    /// </summary>
    public interface IMetricsManagerController
    {
        /// <summary>
        /// Returns list of agents
        /// </summary>
        IActionResult Get();
    }
}
