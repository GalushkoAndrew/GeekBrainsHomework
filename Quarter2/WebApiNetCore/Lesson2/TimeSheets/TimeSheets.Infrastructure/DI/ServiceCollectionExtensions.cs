using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Auth;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Consumer;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Contract;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.ContractWorkType;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Employee;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Invoice;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Work;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.WorkType;
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
            service.AddSingleton<IUserService, UserService>();

            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();

            service.AddTransient<IEmployeeManager, EmployeeManager>();
            service.AddTransient<IManagerBase<Consumer, ConsumerDto>, ConsumerManager>();
            service.AddTransient<IManagerBase<Contract, ContractDto>, ContractManager>();
            service.AddTransient<IManagerBase<ContractWorkType, ContractWorkTypeDto>, ContractWorkTypeManager>();
            service.AddTransient<IManagerBase<Invoice, InvoiceDto>, InvoiceManager>();
            service.AddTransient<IManagerBase<Work, WorkDto>, WorkManager>();
            service.AddTransient<IManagerBase<WorkType, WorkTypeDto>, WorkTypeManager>();

            service.AddTransient<ICreateEmployeeValidator, CreateEmployeeValidator>();
            service.AddTransient<IUpdateEmployeeValidator, UpdateEmployeeValidator>();
            service.AddTransient<IDeleteEmployeeValidator, DeleteEmployeeValidator>();

            service.AddTransient<ICreateConsumerValidator, CreateConsumerValidator>();
            service.AddTransient<IUpdateConsumerValidator, UpdateConsumerValidator>();
            service.AddTransient<IDeleteConsumerValidator, DeleteConsumerValidator>();

            service.AddTransient<ICreateContractValidator, CreateContractValidator>();
            service.AddTransient<IUpdateContractValidator, UpdateContractValidator>();
            service.AddTransient<IDeleteContractValidator, DeleteContractValidator>();

            service.AddTransient<ICreateContractWorkTypeValidator, CreateContractWorkTypeValidator>();
            service.AddTransient<IUpdateContractWorkTypeValidator, UpdateContractWorkTypeValidator>();
            service.AddTransient<IDeleteContractWorkTypeValidator, DeleteContractWorkTypeValidator>();

            service.AddTransient<ICreateInvoiceValidator, CreateInvoiceValidator>();
            service.AddTransient<IUpdateInvoiceValidator, UpdateInvoiceValidator>();
            service.AddTransient<IDeleteInvoiceValidator, DeleteInvoiceValidator>();

            service.AddTransient<ICreateWorkValidator, CreateWorkValidator>();
            service.AddTransient<IUpdateWorkValidator, UpdateWorkValidator>();
            service.AddTransient<IDeleteWorkValidator, DeleteWorkValidator>();

            service.AddTransient<ICreateWorkTypeValidator, CreateWorkTypeValidator>();
            service.AddTransient<IUpdateWorkTypeValidator, UpdateWorkTypeValidator>();
            service.AddTransient<IDeleteWorkTypeValidator, DeleteWorkTypeValidator>();

            service.AddTransient(typeof(ICreateBase<,>), typeof(CreateBase<,>));
            service.AddTransient(typeof(IUpdateBase<,>), typeof(UpdateBase<,>));
            service.AddTransient(typeof(IDeleteBase<>), typeof(DeleteBase<>));

            return service;
        }
    }
}
