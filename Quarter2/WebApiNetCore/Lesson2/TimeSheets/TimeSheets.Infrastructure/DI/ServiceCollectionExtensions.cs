using GeekBrains.Learn.TimeSheets.Infrastructure.Managers;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.DI
{
    /// <summary>
    /// Service collection extension methods
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds required services
        /// </summary>
        /// <param name="service">Service collection</param>
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();
            service.AddTransient<IEmployeeManager, EmployeeManager>();

            return service;
        }
    }
}
