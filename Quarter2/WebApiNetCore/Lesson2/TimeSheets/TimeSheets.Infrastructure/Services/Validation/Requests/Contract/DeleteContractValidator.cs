using FluentValidation;
using FluentValidation.Results;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Contract
{
    /// <inheritdoc/>
    public sealed class DeleteContractValidator : FluentValidationService<Domain.Contract>, IDeleteContractValidator
    {
        /// <inheritdoc/>
        public DeleteContractValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.Contract.Delete.1");
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(ValidationContext<Domain.Contract> context)
        {
            if (context.InstanceToValidate == null) {
                var failure = new ValidationFailure("Contract", "Удаление невозможно. Контракт не найден") {
                    ErrorCode = "Err.Contract.Delete.2"
                };
                return new ValidationResult(new[] { failure });
            }
            return base.Validate(context);
        }
    }
}
