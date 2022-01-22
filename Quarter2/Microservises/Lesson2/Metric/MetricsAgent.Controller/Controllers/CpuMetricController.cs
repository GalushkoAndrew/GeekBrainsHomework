using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.DTO;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers.Base;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller
{
    /// <summary>
    /// Cpu metrics controller
    /// </summary>
    public class CpuMetricController : MetricsController<CpuMetric, CpuMetricDto>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public CpuMetricController(IMetricsManager<CpuMetric, CpuMetricDto> manager, ILogger<CpuMetricController> logger) : base(manager, logger)
        {
        }
    }
}
