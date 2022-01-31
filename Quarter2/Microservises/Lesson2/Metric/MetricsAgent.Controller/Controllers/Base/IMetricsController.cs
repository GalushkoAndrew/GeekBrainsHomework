using System;
using GeekBrains.Learn.Core.DTO.Base;
using Microsoft.AspNetCore.Mvc;

namespace GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers.Base
{
    /// <summary>
    /// Metric controller interface
    /// </summary>
    /// <typeparam name="TDto">Dto</typeparam>
    public interface IMetricsController<TDto>
        where TDto : IMetricDto
    {
        /// <summary>
        /// Returns agent's metrics filtered by dates
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        IActionResult GetMetricsFromAgent(DateTime fromTime, DateTime toTime);

        /// <summary>
        /// Creates entity
        /// </summary>
        /// <param name="dto">dto</param>
        /// <returns>created Dto</returns>
        IActionResult Create(TDto dto);

        /// <summary>
        /// Get single entity
        /// </summary>
        IActionResult Get(int id);

        /// <summary>
        /// Update entity
        /// </summary>
        IActionResult Update(TDto dto);

        /// <summary>
        /// Delete entity
        /// </summary>
        IActionResult Delete(int id);
    }
}
