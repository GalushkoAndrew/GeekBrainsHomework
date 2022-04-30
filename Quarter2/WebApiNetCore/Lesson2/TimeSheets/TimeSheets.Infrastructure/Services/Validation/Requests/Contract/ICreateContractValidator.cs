using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Contract
{
    /// <inheritdoc/>
    public interface ICreateContractValidator : IValidationService<ContractDto>
    {
    }
}
