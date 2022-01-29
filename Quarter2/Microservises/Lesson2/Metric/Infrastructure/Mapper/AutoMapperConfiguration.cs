using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace GeekBrains.Learn.Core.Infrastructure.Mapper
{
    /// <summary>
    /// AutoMapper's config
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Adds auto mapper
        /// </summary>
        /// <param name="service">Service collection</param>
        public static IServiceCollection AddMapper(this IServiceCollection service)
        {
            return service.AddAutoMapper(a =>
            {
                a.CreateMap<CpuMetric, CpuMetricDto>().ReverseMap();
                a.CreateMap<DotnetMetric, DotnetMetricDto>().ReverseMap();
                a.CreateMap<HddMetric, HddMetricDto>().ReverseMap();
                a.CreateMap<NetworkMetric, NetworkMetricDto>().ReverseMap();
                a.CreateMap<RamMetric, RamMetricDto>().ReverseMap();
                a.CreateMap<Agent, AgentDto>();
            });
        }
    }
}
