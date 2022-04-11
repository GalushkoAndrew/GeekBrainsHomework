using GeekBrains.Learn.TimeSheets.Controllers.Base;
using GeekBrains.Learn.TimeSheets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.TimeSheets.Controllers
{
    /// <summary>
    /// Invoice controller
    /// </summary>
    public class InvoiceController : GeneralCrudController<InvoiceDto>
    {
        /// <summary>
        /// Get report of single entity
        /// </summary>
        /// <returns>InvoiceReportDto</returns>
        [HttpGet("report/{id}")]
        public IActionResult GetReport(int id)
        {
            return Ok();
        }
    }
}
