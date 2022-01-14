using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Network metric manager
    /// </summary>
    public class NetworkMetricsManager : INetworkMetricsManager
    {
        private readonly IRepository<NetworkMetric> _repository;

        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricsManager(IRepository<NetworkMetric> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public List<NetworkMetric> GetMetricsFromAgent(DateTime fromTime, DateTime toTime)
        {
            return _repository.GetListFiltered(fromTime, toTime);
        }
    }
}
