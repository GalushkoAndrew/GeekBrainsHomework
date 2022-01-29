using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DTO;

namespace GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces
{
    /// <summary>
    /// Agent's manager interface
    /// </summary>
    public interface IAgentManager
    {
        /// <summary>
        /// Create entity
        /// </summary>
        void Create(string uri);

        /// <summary>
        /// Get entity list
        /// </summary>
        List<AgentDto> GetAll();

        /// <summary>
        /// Returns Cpu metrics
        /// </summary>
        /// <param name="agentId">agent Id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<CpuMetricDto> GetCpuMetric(int agentId, DateTime fromTime, DateTime toTime);

        /// <summary>
        /// Returns Dotnet metrics
        /// </summary>
        /// <param name="agentId">agent Id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<DotnetMetricDto> GetDotnetMetric(int agentId, DateTime fromTime, DateTime toTime);

        /// <summary>
        /// Returns Hdd metrics
        /// </summary>
        /// <param name="agentId">agent Id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<HddMetricDto> GetHddMetric(int agentId, DateTime fromTime, DateTime toTime);

        /// <summary>
        /// Returns Network metrics
        /// </summary>
        /// <param name="agentId">agent Id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<NetworkMetricDto> GetNetworkMetric(int agentId, DateTime fromTime, DateTime toTime);

        /// <summary>
        /// Returns Ram metrics
        /// </summary>
        /// <param name="agentId">agent Id</param>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<RamMetricDto> GetRamMetric(int agentId, DateTime fromTime, DateTime toTime);

    }
}
