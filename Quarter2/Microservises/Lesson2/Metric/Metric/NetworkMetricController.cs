using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.Metric.Controller
{
    /// <summary>
    /// Network metrics controller
    /// </summary>
    [Route("api/network")]
    public class NetworkMetricController : MetricControllerBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricController(INetworkManager cpuManager) : base(cpuManager)
        {
        }
    }
}
