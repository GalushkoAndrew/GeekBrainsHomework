using System;
using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.Core.DAO.Model.Base;
using GeekBrains.Learn.Core.DTO.Base;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <inheritdoc/>
    public class MetricsManager<TEntity, TDto> : IMetricsManager<TEntity, TDto>
        where TEntity : class, IMetric
        where TDto : IMetricDto
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        public MetricsManager(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public TDto Create(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var entityDb = _repository.Create(entity);
            return _mapper.Map<TDto>(entityDb);
        }

        /// <inheritdoc/>
        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        /// <inheritdoc/>
        public TDto Get(int id)
        {
            var entity = _repository.Get(id);
            return _mapper.Map<TDto>(entity);
        }

        /// <inheritdoc/>
        public List<TDto> GetMetricsFromAgent(DateTime fromTime, DateTime toTime)
        {
            var entities = _repository.GetFilteredList(fromTime, toTime);
            return _mapper.Map<List<TDto>>(entities);
        }

        /// <inheritdoc/>
        public TDto Update(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var entityDb = _repository.Update(entity);
            return _mapper.Map<TDto>(entityDb);
        }
    }
}
