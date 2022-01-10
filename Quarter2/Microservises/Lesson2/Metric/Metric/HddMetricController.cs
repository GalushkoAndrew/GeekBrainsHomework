using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Hdd metrics controller
    /// </summary>
    [Route("api/hdd")]
    public class HddMetricController : MetricControllerBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public HddMetricController(IHddManager cpuManager) : base(cpuManager)
        {
        }
    }
}
