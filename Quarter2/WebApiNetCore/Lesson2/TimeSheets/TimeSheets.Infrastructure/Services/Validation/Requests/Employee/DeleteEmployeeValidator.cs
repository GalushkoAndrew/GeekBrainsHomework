using FluentValidation;
using FluentValidation.Results;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Employee
{
    /// <inheritdoc/>
    public sealed class DeleteEmployeeValidator : FluentValidationService<Domain.Employee>, IDeleteEmployeeValidator
    {
        /// <inheritdoc/>
        public DeleteEmployeeValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Идентификатор удаляемого исполнителя должен быть положительным")
                .WithErrorCode("Err.Employee.Delete.1");
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(ValidationContext<Domain.Employee> context)
        {
            if (context.InstanceToValidate == null) {
                var failure = new ValidationFailure("Employee", "Удаление невозможно. Исполнитель не найден") {
                    ErrorCode = "Err.Employee.Delete.2"
                };
                return new ValidationResult(new[] { failure });
            }
            return base.Validate(context);
        }
    }
}
