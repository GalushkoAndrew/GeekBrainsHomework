using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.ContractWorkType
{
    /// <inheritdoc/>
    public sealed class UpdateContractWorkTypeValidator : FluentValidationService<ContractWorkTypeDto>, IUpdateContractWorkTypeValidator
    {
        /// <inheritdoc/>
        public UpdateContractWorkTypeValidator()
        {
            RuleFor(x => x.WorkType)
                .NotEmpty()
                .WithMessage("Тип работы не может быть пустым")
                .WithErrorCode("Err.ContractWorkType.Update.1");
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.ContractWorkType.Update.2");
            RuleFor(x => x.Price)
                .LessThan(0)
                .WithMessage("Цена не может быть отрицательной")
                .WithErrorCode("Err.ContractWorkType.Update.3");
        }
    }
}
