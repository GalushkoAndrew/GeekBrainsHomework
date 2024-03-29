﻿using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.DTO;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;
using GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers.Base;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers
{
    /// <summary>
    /// Hdd metrics controller
    /// </summary>
    public class HddMetricController : MetricsController<HddMetric, HddMetricDto>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public HddMetricController(IMetricsManager<HddMetric, HddMetricDto> manager, ILogger<HddMetricController> logger) : base(manager, logger)
        {
        }
    }
}
