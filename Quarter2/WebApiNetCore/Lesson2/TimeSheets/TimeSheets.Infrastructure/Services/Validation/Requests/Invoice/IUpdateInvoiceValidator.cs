using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Invoice
{
    /// <inheritdoc/>
    public interface IUpdateInvoiceValidator : IValidationService<InvoiceDto>
    {
    }
}
