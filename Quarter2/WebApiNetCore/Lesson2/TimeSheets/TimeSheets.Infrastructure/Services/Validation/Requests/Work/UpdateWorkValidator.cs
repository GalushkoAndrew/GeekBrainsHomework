using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Work
{
    /// <inheritdoc/>
    public sealed class UpdateWorkValidator : FluentValidationService<WorkDto>, IUpdateWorkValidator
    {
        /// <inheritdoc/>
        public UpdateWorkValidator()
        {
            RuleFor(x => x.ContractWorkType)
                .NotEmpty()
                .WithMessage("Прайс не может быть пустым")
                .WithErrorCode("Err.Work.Update.1");
            RuleFor(x => x.Employee)
                .NotEmpty()
                .WithMessage("Исполнитель не может быть пустым")
                .WithErrorCode("Err.Work.Update.3");
            RuleFor(x => x.DateBegin)
                .Must((src, dateBegin) => src.DateEnd > dateBegin)
                .WithMessage("Дата начала должна быть меньше даты окончания")
                .WithErrorCode("Err.Work.Update.4");
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.Work.Update.2");
        }
    }
}
