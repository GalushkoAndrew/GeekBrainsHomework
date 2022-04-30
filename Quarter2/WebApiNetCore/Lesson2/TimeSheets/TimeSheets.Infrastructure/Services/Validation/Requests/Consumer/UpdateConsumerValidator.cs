using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Consumer
{
    /// <inheritdoc/>
    public sealed class UpdateConsumerValidator : FluentValidationService<ConsumerDto>, IUpdateConsumerValidator
    {
        /// <inheritdoc/>
        public UpdateConsumerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .WithErrorCode("Err.Consumer.Update.1");
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.Consumer.Update.2");
        }
    }
}
