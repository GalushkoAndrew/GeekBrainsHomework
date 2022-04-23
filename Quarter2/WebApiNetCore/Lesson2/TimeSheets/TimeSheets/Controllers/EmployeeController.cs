using System;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.TimeSheets.Controllers
{
    /// <summary>
    /// Employee controller
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public sealed class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _manager;

        /// <inheritdoc/>
        public EmployeeController(IEmployeeManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Create entity
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] EmployeeDto dto)
        {
            try
            {
                _manager.Create(dto);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        [HttpPut]
        public IActionResult Update([FromBody] EmployeeDto dto)
        {
            try
            {
                _manager.Update(dto);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _manager.Delete(id);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get single entity
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var res = _manager.GetById(id);

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

        /// <summary>
        /// Get list using pagination
        /// </summary>
        /// <param name="skip">how much records to skip</param>
        /// <param name="take">records count to return</param>
        [HttpGet]
        public IActionResult GetPageList([FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                var res = _manager.GetPageList(skip, take);

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
