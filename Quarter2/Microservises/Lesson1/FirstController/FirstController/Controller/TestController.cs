using System;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.FirstController
{
    /// <summary>
    /// Test controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TemperatureManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public TestController(TemperatureManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Returns list of temperature filtered by dates.
        /// There is pre-created 4 temperatures, from "2021-01-01T00:00:00" to "2021-01-04T00:00:00"
        /// </summary>
        /// <returns>temperature list</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] DateTime dateBegin, [FromQuery] DateTime dateEnd)
        {
            return Ok(_manager.GetList(dateBegin, dateEnd));
        }

        /// <summary>
        /// Add temperature
        /// </summary>
        /// <param name="item">Temperature info</param>
        /// <returns>true if success</returns>
        [HttpPost]
        public IActionResult Create([FromQuery] Temperature item)
        {
            return Ok(_manager.Create(item));
        }

        /// <summary>
        /// Edit temperature
        /// Find it by date-time
        /// </summary>
        /// <param name="item">New temperature info</param>
        /// <returns>true if success</returns>
        [HttpPut]
        public IActionResult Update([FromQuery] Temperature item)
        {
            return Ok(_manager.Update(item));
        }

        /// <summary>
        /// Delete temperature by date period
        /// </summary>
        /// <returns>Count deleted values</returns>
        [HttpDelete]
        public IActionResult Delete([FromQuery] DateTime dateBegin, [FromQuery] DateTime dateEnd)
        {
            return Ok(_manager.Delete(dateBegin, dateEnd));
        }
    }
}
