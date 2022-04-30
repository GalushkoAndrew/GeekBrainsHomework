using GeekBrains.Learn.TimeSheets.Controllers.Base;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;

namespace GeekBrains.Learn.TimeSheets.Controllers
{
    /// <summary>
    /// Invoice controller
    /// </summary>
    public class InvoiceController : GeneralCrudController<Invoice, InvoiceDto>
    {
        /// <inheritdoc/>
        public InvoiceController(IManagerBase<Invoice, InvoiceDto> manager) : base(manager)
        {
        }
    }
}
