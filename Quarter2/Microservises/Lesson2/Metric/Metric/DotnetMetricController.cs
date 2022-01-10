using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Dotnet metrics controller
    /// </summary>
    [Route("api/dotnet")]
    public class DotnetMetricController : MetricControllerBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DotnetMetricController(IDotnetManager cpuManager) : base(cpuManager)
        {
        }
    }
}
