using FluentValidation;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Invoice
{
    /// <inheritdoc/>
    public sealed class UpdateInvoiceValidator : FluentValidationService<InvoiceDto>, IUpdateInvoiceValidator
    {
        /// <inheritdoc/>
        public UpdateInvoiceValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.Invoice.Update.1");
        }
    }
}
