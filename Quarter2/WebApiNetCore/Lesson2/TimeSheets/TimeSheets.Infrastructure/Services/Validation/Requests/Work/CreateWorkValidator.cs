using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Work
{
    /// <inheritdoc/>
    public sealed class CreateWorkValidator : FluentValidationService<WorkDto>, ICreateWorkValidator
    {
        /// <inheritdoc/>
        public CreateWorkValidator()
        {
            RuleFor(x => x.ContractWorkType)
                .NotEmpty()
                .WithMessage("Прайс не может быть пустым")
                .WithErrorCode("Err.Work.Create.1");
            RuleFor(x => x.Employee)
                .NotEmpty()
                .WithMessage("Исполнитель не может быть пустым")
                .WithErrorCode("Err.Work.Create.3");
            RuleFor(x => x.DateBegin)
                .Must((src, dateBegin) => src.DateEnd > dateBegin)
                .WithMessage("Дата начала должна быть меньше даты окончания")
                .WithErrorCode("Err.Work.Create.4");
            RuleFor(x => x.Id)
                .Empty()
                .WithMessage("Идентификатор должен быть равен 0")
                .WithErrorCode("Err.Work.Create.2");
        }
    }
}
