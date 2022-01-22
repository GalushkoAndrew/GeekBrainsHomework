using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.DTO;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers.Base;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller
{
    /// <summary>
    /// Network metrics controller
    /// </summary>
    public class NetworkMetricController : MetricsController<NetworkMetric, NetworkMetricDto>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricController(IMetricsManager<NetworkMetric, NetworkMetricDto> manager, ILogger<NetworkMetricController> logger) : base(manager, logger)
        {
        }
    }
}
