using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Consumer
{
    /// <inheritdoc/>
    public sealed class CreateConsumerValidator : FluentValidationService<ConsumerDto>, ICreateConsumerValidator
    {
        /// <inheritdoc/>
        public CreateConsumerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .WithErrorCode("Err.Consumer.Create.1");
            RuleFor(x => x.Id)
                .Empty()
                .WithMessage("Идентификатор должен быть равен 0")
                .WithErrorCode("Err.Consumer.Create.2");
        }
    }
}
