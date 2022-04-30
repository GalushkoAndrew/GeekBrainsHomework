using System.Linq;
using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Employee
{
    /// <inheritdoc/>
    public sealed class UpdateEmployeeValidator : FluentValidationService<EmployeeDto>, IUpdateEmployeeValidator
    {
        /// <inheritdoc/>
        public UpdateEmployeeValidator()
        {
            var msg = "Ошибка в поле {PropertyName}: значение {PropertyValue}.";

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(msg)
                .WithMessage("Имя не может быть пустым")
                .WithErrorCode("Err.Employee.Update.1");
            RuleFor(x => x.Name)
                .Must(c => c.All(char.IsLetter))
                .WithMessage(msg)
                .WithMessage("Имя не может содержать цифры")
                .WithErrorCode("Err.Employee.Update.2");
        }
    }
}
