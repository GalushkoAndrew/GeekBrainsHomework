using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Consumer;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers
{
    /// <summary>
    /// Consumer manager
    /// </summary>
    public class ConsumerManager : IManagerBase<Consumer, ConsumerDto>
    {
        private readonly IRepository<Consumer> _repository;
        private readonly IMapper _mapper;
        private readonly ICreateBase<Consumer, ConsumerDto> _createOperation;
        private readonly IUpdateBase<Consumer, ConsumerDto> _updateOperation;
        private readonly IDeleteBase<Consumer> _deleteOperation;
        private readonly ICreateConsumerValidator _createValidator;
        private readonly IUpdateConsumerValidator _updateValidator;
        private readonly IDeleteConsumerValidator _deleteValidator;

        /// <inheritdoc/>
        public ConsumerManager(
            IRepository<Consumer> repository,
            IMapper mapper,
            ICreateBase<Consumer, ConsumerDto> createOperation,
            IUpdateBase<Consumer, ConsumerDto> updateOperation,
            IDeleteBase<Consumer> deleteOperation,
            ICreateConsumerValidator createValidator,
            IUpdateConsumerValidator updateValidator,
            IDeleteConsumerValidator deleteValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createOperation = createOperation;
            _updateOperation = updateOperation;
            _deleteOperation = deleteOperation;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _deleteValidator = deleteValidator;
        }

        /// <inheritdoc/>
        public IOperationResult Create(ConsumerDto dto)
        {
            return _createOperation.Create(dto, _createValidator);
        }

        /// <inheritdoc/>
        public IOperationResult Delete(int id)
        {
            return _deleteOperation.Delete(id, _deleteValidator);
        }

        /// <inheritdoc/>
        public ConsumerDto GetById(int id)
        {
            return _mapper.Map<ConsumerDto>(_repository.GetById(id));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<ConsumerDto> GetPageList(int skip, int take)
        {
            return _mapper.Map<IReadOnlyCollection<ConsumerDto>>(_repository.GetPageList(skip, take));
        }

        /// <inheritdoc/>
        public IOperationResult Update(ConsumerDto dto)
        {
            return _updateOperation.Update(dto, _updateValidator);
        }
    }
}
