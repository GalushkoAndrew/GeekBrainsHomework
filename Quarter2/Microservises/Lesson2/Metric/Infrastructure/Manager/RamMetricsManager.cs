using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Ram metric manager
    /// </summary>
    public class RamMetricsManager : IRamMetricsManager
    {
        private readonly IRepository<RamMetric> _repository;

        /// <summary>
        /// ctor
        /// </summary>
        public RamMetricsManager(IRepository<RamMetric> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public List<RamMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime)
        {
            return _repository.GetListFiltered(fromTime, toTime);
        }
    }
}
