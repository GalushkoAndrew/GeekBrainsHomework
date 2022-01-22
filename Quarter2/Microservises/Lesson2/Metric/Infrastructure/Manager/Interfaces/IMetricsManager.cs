﻿using System;
using System.Collections.Generic;
using GeekBrains.Learn.Core.DAO.Model.Base;
using GeekBrains.Learn.Core.DTO.Base;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Base metric manager interface
    /// </summary>
    /// <typeparam name="TEntity">entity</typeparam>
    /// <typeparam name="TDto">Dto</typeparam>
    public interface IMetricsManager<TEntity, TDto>
        where TEntity : IBaseModel
        where TDto : IBaseModelDto
    {
        /// <summary>
        /// Returns metrics
        /// </summary>
        /// <param name="fromTime">begin time</param>
        /// <param name="toTime">end time</param>
        List<TDto> GetMetricsFromAgent(DateTime fromTime, DateTime toTime);

        /// <summary>
        /// Creates entity
        /// </summary>
        /// <param name="dto">dto</param>
        TDto Create(TDto dto);

        /// <summary>
        /// Get single entity
        /// </summary>
        TDto Get(int id);

        /// <summary>
        /// Update entity
        /// </summary>
        TDto Update(TDto entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        int Delete(int id);
    }
}
