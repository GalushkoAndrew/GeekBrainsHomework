using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.DTO;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;
using GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers.Base;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers
{
    /// <summary>
    /// Dotnet metrics controller
    /// </summary>
    public class DotnetMetricController : MetricsController<DotnetMetric, DotnetMetricDto>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DotnetMetricController(IMetricsManager<DotnetMetric, DotnetMetricDto> manager, ILogger<DotnetMetricController> logger) : base(manager, logger)
        {
        }
    }
}
