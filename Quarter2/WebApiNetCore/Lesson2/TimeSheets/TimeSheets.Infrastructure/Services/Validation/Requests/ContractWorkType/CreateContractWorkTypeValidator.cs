using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.ContractWorkType
{
    /// <inheritdoc/>
    public sealed class CreateContractWorkTypeValidator : FluentValidationService<ContractWorkTypeDto>, ICreateContractWorkTypeValidator
    {
        /// <inheritdoc/>
        public CreateContractWorkTypeValidator()
        {
            RuleFor(x => x.WorkType)
                .NotEmpty()
                .WithMessage("Тип работы не может быть пустым")
                .WithErrorCode("Err.ContractWorkType.Create.1");
            RuleFor(x => x.Id)
                .Empty()
                .WithMessage("Идентификатор должен быть равен 0")
                .WithErrorCode("Err.ContractWorkType.Create.2");
            RuleFor(x => x.Price)
                .LessThan(0)
                .WithMessage("Цена не может быть отрицательной")
                .WithErrorCode("Err.ContractWorkType.Create.3");
        }
    }
}
