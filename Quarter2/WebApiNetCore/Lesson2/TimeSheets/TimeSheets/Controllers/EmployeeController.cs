using System;
using GeekBrains.Learn.TimeSheets.Controllers.Base;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.TimeSheets.Controllers
{
    /// <summary>
    /// Employee controller
    /// </summary>
    public sealed class EmployeeController : GeneralCrudController<Employee, EmployeeDto>
    {
        private readonly IEmployeeManager _manager;

        /// <inheritdoc/>
        public EmployeeController(IEmployeeManager manager) : base(manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get list filtered by part of name
        /// </summary>
        [HttpGet("search")]
        public IActionResult GetByTerm([FromQuery] string term)
        {
            try
            {
                var res = _manager.GetByTerm(term);

                if (res == null)
                {
                    return NotFound();
                }

                return Ok(res);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
