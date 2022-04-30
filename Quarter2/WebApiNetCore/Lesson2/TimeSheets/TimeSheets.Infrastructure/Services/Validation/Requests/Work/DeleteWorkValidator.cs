using FluentValidation;
using FluentValidation.Results;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Work
{
    /// <inheritdoc/>
    public sealed class DeleteWorkValidator : FluentValidationService<Domain.Work>, IDeleteWorkValidator
    {
        /// <inheritdoc/>
        public DeleteWorkValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.Work.Delete.1");
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(ValidationContext<Domain.Work> context)
        {
            if (context.InstanceToValidate == null) {
                var failure = new ValidationFailure("Work", "Удаление невозможно. Работа не найдена") {
                    ErrorCode = "Err.Work.Delete.2"
                };
                return new ValidationResult(new[] { failure });
            }
            return base.Validate(context);
        }
    }
}
