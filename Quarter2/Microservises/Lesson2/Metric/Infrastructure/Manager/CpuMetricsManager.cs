using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Cpu metric manager
    /// </summary>
    public class CpuMetricsManager : ICpuMetricsManager
    {
        private readonly IRepository<CpuMetric> _repository;

        /// <summary>
        /// ctor
        /// </summary>
        public CpuMetricsManager(IRepository<CpuMetric> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public List<CpuMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime)
        {
            return _repository.GetListFiltered(fromTime, toTime);
        }
    }
}
