using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Invoice
{
    /// <inheritdoc/>
    public sealed class CreateInvoiceValidator : FluentValidationService<InvoiceDto>, ICreateInvoiceValidator
    {
        /// <inheritdoc/>
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.Id)
                .Empty()
                .WithMessage("Идентификатор должен быть равен 0")
                .WithErrorCode("Err.Invoice.Create.1");
        }
    }
}
