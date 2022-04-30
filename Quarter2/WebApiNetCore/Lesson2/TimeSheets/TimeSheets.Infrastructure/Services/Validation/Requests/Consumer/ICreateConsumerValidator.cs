using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Consumer
{
    /// <inheritdoc/>
    public interface ICreateConsumerValidator : IValidationService<ConsumerDto>
    {
    }
}
