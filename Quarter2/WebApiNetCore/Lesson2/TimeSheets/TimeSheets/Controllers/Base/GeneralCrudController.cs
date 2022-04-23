using GeekBrains.Learn.TimeSheets.Dto.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.TimeSheets.Controllers.Base
{
    /// <summary>
    /// General Crud Controller
    /// </summary>
    /// <typeparam name="TDto">dto</typeparam>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public abstract class GeneralCrudController<TDto> : ControllerBase
        where TDto : IdentifierDto
    {
        /// <summary>
        /// Create entity
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] TDto dto)
        {
            return Ok();
        }

        /// <summary>
        /// Update entity
        /// </summary>
        [HttpPut]
        public IActionResult Update([FromBody] TDto dto)
        {
            return Ok();
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Get list
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Get single entity
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
    }
}
