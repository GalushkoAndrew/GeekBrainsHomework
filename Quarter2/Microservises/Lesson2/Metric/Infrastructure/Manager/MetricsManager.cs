using System;
using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.Core.DAO.Model.Base;
using GeekBrains.Learn.Core.DTO.Base;
using GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <inheritdoc/>
    public class MetricsManager<TEntity, TDto> : IMetricsManager<TEntity, TDto>
        where TEntity : class, IBaseModel
        where TDto : IBaseModelDto
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
        public TDto Create(TDto entity)
        {
            return _mapper.Map<TDto>(_repository.Create(_mapper.Map<TEntity>(entity)));
        }

        /// <inheritdoc/>
        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        /// <inheritdoc/>
        public TDto Get(int id)
        {
            return _mapper.Map<TDto>(_repository.Get(id));
        }

        /// <inheritdoc/>
        public List<TDto> GetMetricsFromAgent(DateTime fromTime, DateTime toTime)
        {
            return _mapper.Map<List<TDto>>(_repository.GetListFiltered(fromTime, toTime));
        }

        /// <inheritdoc/>
        public TDto Update(TDto entity)
        {
            return _mapper.Map<TDto>(_repository.Update(_mapper.Map<TEntity>(entity)));
        }
    }
}
