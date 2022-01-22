using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.DTO;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers.Base;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller
{
    /// <summary>
    /// Ram metrics controller
    /// </summary>
    public class RamMetricController : MetricsController<RamMetric, RamMetricDto>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RamMetricController(IMetricsManager<RamMetric, RamMetricDto> manager, ILogger<RamMetricController> logger) : base(manager, logger)
        {
        }
    }
}
