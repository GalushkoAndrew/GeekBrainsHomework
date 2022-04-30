using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Employee
{
    /// <inheritdoc/>
    public interface ICreateEmployeeValidator : IValidationService<EmployeeDto>
    {
    }
}
