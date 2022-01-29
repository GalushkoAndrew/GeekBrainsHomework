using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using AutoMapper;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.DTO;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Agent's manager
    /// </summary>
    public class AgentManager : IAgentManager
    {
        private readonly IAgentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;

        /// <inheritdoc/>
        public AgentManager(IAgentRepository repository, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _clientFactory = httpClientFactory;
        }

        /// <inheritdoc/>
        public void Create(string uri)
{
            _repository.Create(new Agent { Uri = uri });
        }

        /// <inheritdoc/>
        public List<AgentDto> GetAll()
        {
            return _mapper.Map<List<AgentDto>>(_repository.GetAll());
        }

        /// <inheritdoc/>
        public List<CpuMetricDto> GetCpuMetric(int agentId, DateTime fromTime, DateTime toTime)
        {
            return GetMetric<CpuMetricDto>(agentId, fromTime, toTime, "Cpu");
        }

        /// <inheritdoc/>
        public List<DotnetMetricDto> GetDotnetMetric(int agentId, DateTime fromTime, DateTime toTime)
        {
            return GetMetric<DotnetMetricDto>(agentId, fromTime, toTime, "Dotnet");
        }

        /// <inheritdoc/>
        public List<HddMetricDto> GetHddMetric(int agentId, DateTime fromTime, DateTime toTime)
        {
            return GetMetric<HddMetricDto>(agentId, fromTime, toTime, "Hdd");
        }

        /// <inheritdoc/>
        public List<NetworkMetricDto> GetNetworkMetric(int agentId, DateTime fromTime, DateTime toTime)
        {
            return GetMetric<NetworkMetricDto>(agentId, fromTime, toTime, "Network");
        }

        /// <inheritdoc/>
        public List<RamMetricDto> GetRamMetric(int agentId, DateTime fromTime, DateTime toTime)
        {
            return GetMetric<RamMetricDto>(agentId, fromTime, toTime, "Ram");
        }

        private List<T> GetMetric<T>(int agentId, DateTime fromTime, DateTime toTime, string metricName)
        {
            var entity = _repository.GetById(agentId);
            if (entity == null)
            {
                return null;
            }

            var client = _clientFactory.CreateClient(metricName + "Client");
            var request = new HttpRequestMessage(HttpMethod.Get, entity.Uri + "/" + metricName + $"Metric/from/{fromTime}/to/{toTime}");
            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                var metrics = JsonSerializer.DeserializeAsync<List<T>>(
                    responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
                return metrics;
            }

            return null;
        }
    }
}
