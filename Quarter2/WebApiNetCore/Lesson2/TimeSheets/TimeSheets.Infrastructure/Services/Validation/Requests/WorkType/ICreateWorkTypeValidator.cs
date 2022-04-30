using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.WorkType
{
    /// <inheritdoc/>
    public interface ICreateWorkTypeValidator : IValidationService<WorkTypeDto>
    {
    }
}
