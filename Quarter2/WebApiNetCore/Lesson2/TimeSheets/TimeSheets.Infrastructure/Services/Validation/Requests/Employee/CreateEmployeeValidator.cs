using System.Linq;
using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Employee
{
    /// <inheritdoc/>
    public sealed class CreateEmployeeValidator : FluentValidationService<EmployeeDto>, ICreateEmployeeValidator
    {
        /// <inheritdoc/>
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .WithErrorCode("Err.Employee.Create.1");
            RuleFor(x => x.Name)
                .Must(c => c.All(char.IsLetter))
                .WithMessage("Имя не может содержать цифры")
                .WithErrorCode("Err.Employee.Create.2");
            RuleFor(x => x.Id)
                .Empty()
                .WithMessage("Идентификатор должен быть равен 0")
                .WithErrorCode("Err.Employee.Create.3");
        }
    }
}
