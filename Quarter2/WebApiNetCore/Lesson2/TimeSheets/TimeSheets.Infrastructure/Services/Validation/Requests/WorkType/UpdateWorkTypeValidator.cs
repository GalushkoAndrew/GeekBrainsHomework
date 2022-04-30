using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.WorkType
{
    /// <inheritdoc/>
    public sealed class UpdateWorkTypeValidator : FluentValidationService<WorkTypeDto>, IUpdateWorkTypeValidator
    {
        /// <inheritdoc/>
        public UpdateWorkTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .WithErrorCode("Err.WorkType.Update.1");
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.WorkType.Update.2");
        }
    }
}
