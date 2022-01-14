using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Dotnet metric manager
    /// </summary>
    public class DotnetMetricsManager : IDotnetMetricsManager
    {
        private readonly IRepository<DotnetMetric> _repository;

        /// <summary>
        /// ctor
        /// </summary>
        public DotnetMetricsManager(IRepository<DotnetMetric> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public List<DotnetMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime)
        {
            return _repository.GetListFiltered(fromTime, toTime);
        }
    }
}
