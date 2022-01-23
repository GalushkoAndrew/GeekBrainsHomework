using System;
using System.Text.Json;
using GeekBrains.Learn.Core.DAO.Model.Base;
using GeekBrains.Learn.Core.DTO.Base;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers.Base
{
    /// <summary>
    /// Base controller
    /// </summary>
    /// <typeparam name="TEntity">entity</typeparam>
    /// <typeparam name="TDto">Dto</typeparam>
    [Route("[controller]")]
    [ApiController]
    public abstract class MetricsController<TEntity, TDto> : ControllerBase, IMetricsController<TDto>
        where TEntity : IMetric
        where TDto : IMetricDto
    {
        private readonly IMetricsManager<TEntity, TDto> _manager;
        private readonly ILogger _logger;

        /// <summary>
        /// ctor
        /// </summary>
        public MetricsController(IMetricsManager<TEntity, TDto> manager, ILogger logger)
        {
            _manager = manager;
            _logger = logger;
        }

        /// <summary>
        /// Returns agent's metrics filtered by dates
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime)
        {
            try
            {
                Log($"Input parameters: fromTime = {fromTime}, toTime = {toTime}");
                return Ok(_manager.GetMetricsFromAgent(fromTime, toTime));
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates entity
        /// </summary>
        /// <param name="dto">dto</param>
        /// <returns>created Dto</returns>
        [HttpPost]
        public IActionResult Create(TDto dto)
        {
            try
            {
                Log($"Input parameters: {JsonSerializer.Serialize(dto)}");
                return Ok(_manager.Create(dto));
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get single entity
        /// </summary>
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                Log($"Input parameters: {id}");
                TDto dto = _manager.Get(id);
                if (dto == null)
                {
                    return NotFound();
                }

                return Ok(dto);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        [HttpPut]
        public IActionResult Update(TDto dto)
        {
            try
            {
                Log($"Input parameters: {JsonSerializer.Serialize(dto)}");
                return Ok(_manager.Update(dto));
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Log($"Input parameters: {id}");
                var result = _manager.Delete(id);
                if (result == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return BadRequest(ex);
            }
        }

        private void Log(string message)
        {
            try
            {
                _logger.LogError(message);
            }
            catch (Exception)
            {
            }
        }
    }
}
