using FluentValidation;
using FluentValidation.Results;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Consumer
{
    /// <inheritdoc/>
    public sealed class DeleteConsumerValidator : FluentValidationService<Domain.Consumer>, IDeleteConsumerValidator
    {
        /// <inheritdoc/>
        public DeleteConsumerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.Consumer.Delete.1");
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(ValidationContext<Domain.Consumer> context)
        {
            if (context.InstanceToValidate == null) {
                var failure = new ValidationFailure("Consumer", "Удаление невозможно. Заказчик не найден") {
                    ErrorCode = "Err.Consumer.Delete.2"
                };
                return new ValidationResult(new[] { failure });
            }
            return base.Validate(context);
        }
    }
}
