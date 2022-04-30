using FluentValidation;
using FluentValidation.Results;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Invoice
{
    /// <inheritdoc/>
    public sealed class DeleteInvoiceValidator : FluentValidationService<Domain.Invoice>, IDeleteInvoiceValidator
    {
        /// <inheritdoc/>
        public DeleteInvoiceValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Идентификатор не должен быть равен 0")
                .WithErrorCode("Err.Invoice.Delete.1");
        }

        /// <inheritdoc/>
        public override ValidationResult Validate(ValidationContext<Domain.Invoice> context)
        {
            if (context.InstanceToValidate == null) {
                var failure = new ValidationFailure("Invoice", "Удаление невозможно. Акт выполненных работ не найден") {
                    ErrorCode = "Err.Invoice.Delete.2"
                };
                return new ValidationResult(new[] { failure });
            }
            return base.Validate(context);
        }
    }
}
