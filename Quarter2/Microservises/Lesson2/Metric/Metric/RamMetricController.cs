using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Ram metrics controller
    /// </summary>
    [Route("api/ram")]
    public class RamMetricController : MetricControllerBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RamMetricController(IRamManager cpuManager) : base(cpuManager)
        {
        }
    }
}
