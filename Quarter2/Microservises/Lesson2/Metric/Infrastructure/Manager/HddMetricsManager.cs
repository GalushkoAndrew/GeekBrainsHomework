using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Hdd metric manager
    /// </summary>
    public class HddMetricsManager : IHddMetricsManager
    {
        private readonly IRepository<HddMetric> _repository;

        /// <summary>
        /// ctor
        /// </summary>
        public HddMetricsManager(IRepository<HddMetric> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public List<HddMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime)
        {
            return _repository.GetListFiltered(fromTime, toTime);
        }
    }
}
