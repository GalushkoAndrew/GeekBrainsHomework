using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.WorkType
{
    /// <inheritdoc/>
    public sealed class CreateWorkTypeValidator : FluentValidationService<WorkTypeDto>, ICreateWorkTypeValidator
    {
        /// <inheritdoc/>
        public CreateWorkTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .WithErrorCode("Err.WorkType.Create.1");
            RuleFor(x => x.Id)
                .Empty()
                .WithMessage("Идентификатор должен быть равен 0")
                .WithErrorCode("Err.WorkType.Create.2");
        }
    }
}
