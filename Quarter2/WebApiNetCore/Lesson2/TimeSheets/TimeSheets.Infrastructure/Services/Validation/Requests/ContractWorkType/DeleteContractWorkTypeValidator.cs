using FluentValidation;
using FluentValidation.Results;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.ContractWorkType
{
    /// <inheritdoc/>
    public sealed class DeleteContractWorkTypeValidator : FluentValidationService<Domain.ContractWorkType>, IDeleteContractWorkTypeValidator
    {
        /// <inheritdoc/>
        public DeleteContractWorkTypeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.ContractWorkType.Delete.1");
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(ValidationContext<Domain.ContractWorkType> context)
        {
            if (context.InstanceToValidate == null) {
                var failure = new ValidationFailure("ContractWorkType", "Удаление невозможно. Прайс не найден") {
                    ErrorCode = "Err.ContractWorkType.Delete.2"
                };
                return new ValidationResult(new[] { failure });
            }
            return base.Validate(context);
        }
    }
}
