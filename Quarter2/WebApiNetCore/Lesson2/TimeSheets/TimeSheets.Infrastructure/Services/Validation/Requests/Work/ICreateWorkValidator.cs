using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Work
{
    /// <inheritdoc/>
    public interface ICreateWorkValidator : IValidationService<WorkDto>
    {
    }
}
