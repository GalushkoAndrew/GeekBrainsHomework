using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Cpu metrics controller
    /// </summary>
    [Route("api/cpu")]
    public class CpuMetricController : MetricControllerBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public CpuMetricController(ICpuManager cpuManager) : base(cpuManager)
        {
        }
    }
}
