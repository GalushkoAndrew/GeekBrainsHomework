using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Contract
{
    /// <inheritdoc/>
    public sealed class CreateContractValidator : FluentValidationService<ContractDto>, ICreateContractValidator
    {
        /// <inheritdoc/>
        public CreateContractValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .WithErrorCode("Err.Contract.Create.1");
            RuleFor(x => x.Id)
                .Empty()
                .WithMessage("Идентификатор должен быть равен 0")
                .WithErrorCode("Err.Contract.Create.2");
            RuleFor(x => x.Consumer)
                .NotEmpty()
                .WithMessage("Заканчик должен быть указан")
                .WithErrorCode("Err.Contract.Create.3");
        }
    }
}
