using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Contract
{
    /// <inheritdoc/>
    public sealed class UpdateContractValidator : FluentValidationService<ContractDto>, IUpdateContractValidator
    {
        /// <inheritdoc/>
        public UpdateContractValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .WithErrorCode("Err.Contract.Update.1");
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.Contract.Update.2");
            RuleFor(x => x.Consumer)
                .NotEmpty()
                .WithMessage("Заканчик должен быть указан")
                .WithErrorCode("Err.Contract.Update.3");
        }
    }
}
