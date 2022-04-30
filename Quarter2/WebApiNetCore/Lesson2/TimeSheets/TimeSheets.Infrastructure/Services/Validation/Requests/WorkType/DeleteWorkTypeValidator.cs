using FluentValidation;
using FluentValidation.Results;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.WorkType
{
    /// <inheritdoc/>
    public sealed class DeleteWorkTypeValidator : FluentValidationService<Domain.WorkType>, IDeleteWorkTypeValidator
    {
        /// <inheritdoc/>
        public DeleteWorkTypeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.WorkType.Delete.1");
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(ValidationContext<Domain.WorkType> context)
        {
            if (context.InstanceToValidate == null) {
                var failure = new ValidationFailure("WorkType", "Удаление невозможно. Тип работы не найден") {
                    ErrorCode = "Err.WorkType.Delete.2"
                };
                return new ValidationResult(new[] { failure });
            }
            return base.Validate(context);
        }
    }
}
