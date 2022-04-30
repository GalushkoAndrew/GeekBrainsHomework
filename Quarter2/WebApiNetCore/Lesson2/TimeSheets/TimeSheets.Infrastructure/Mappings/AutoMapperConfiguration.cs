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
                a.CreateMap<Consumer, ConsumerDto>().ReverseMap();
                a.CreateMap<Contract, ContractDto>()
                    .ReverseMap()
                    .ForMember(d => d.Consumer, o => o.Ignore());
                a.CreateMap<ContractWorkType, ContractWorkTypeDto>()
                    .ReverseMap()
                    .ForMember(d => d.WorkType, o => o.Ignore());
                a.CreateMap<Invoice, InvoiceDto>().ReverseMap();
                a.CreateMap<InvoiceRow, InvoiceRowDto>()
                    .ReverseMap()
                    .ForMember(d => d.Invoice, o => o.Ignore())
                    .ForMember(d => d.Work, o => o.Ignore());
                a.CreateMap<Work, WorkDto>()
                    .ReverseMap()
                    .ForMember(d => d.ContractWorkType, o => o.Ignore())
                    .ForMember(d => d.Employee, o => o.Ignore());
                a.CreateMap<WorkType, WorkTypeDto>().ReverseMap();
            });
        }
    }
}
