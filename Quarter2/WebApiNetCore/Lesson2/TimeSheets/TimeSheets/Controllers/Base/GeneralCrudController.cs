using System;
using GeekBrains.Learn.TimeSheets.Dto.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.TimeSheets.Controllers.Base
{
    /// <summary>
    /// General Crud Controller
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TDto">Dto</typeparam>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public abstract class GeneralCrudController<TEntity, TDto> : ControllerBase
        where TDto : IdentifierDto
    {
        private readonly IManagerBase<TEntity, TDto> _manager;

        /// <inheritdoc/>
        public GeneralCrudController(IManagerBase<TEntity, TDto> manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Create entity
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] TDto dto)
        {
            try {
                var res = _manager.Create(dto);
                if (res.IsSuccess) {
                    return Ok();
                }

                return BadRequest(res);
            }
            catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        [HttpPut]
        public IActionResult Update([FromBody] TDto dto)
        {
            try {
                var res = _manager.Update(dto);
                if (res.IsSuccess) {
                    return Ok();
                }

                return BadRequest(res);
            }
            catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                var res = _manager.Delete(id);
                if (res.IsSuccess) {
                    return Ok();
                }

                return BadRequest(res);
            }
            catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Get single entity
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try {
                var res = _manager.GetById(id);

                if (res == null) {
                    return NotFound();
                }

                return Ok(res);
            }
            catch (Exception) {
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
            try {
                var res = _manager.GetPageList(skip, take);

                if (res == null) {
                    return NotFound();
                }

                return Ok(res);
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
