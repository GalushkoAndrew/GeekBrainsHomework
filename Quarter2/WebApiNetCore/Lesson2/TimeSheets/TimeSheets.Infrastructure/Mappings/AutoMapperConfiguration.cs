using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Mappings
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
                a.CreateMap<Employee, EmployeeDto>().ReverseMap();
            });
        }
    }
}
