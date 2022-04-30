using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.ContractWorkType
{
    /// <inheritdoc/>
    public interface ICreateContractWorkTypeValidator : IValidationService<ContractWorkTypeDto>
    {
    }
}
