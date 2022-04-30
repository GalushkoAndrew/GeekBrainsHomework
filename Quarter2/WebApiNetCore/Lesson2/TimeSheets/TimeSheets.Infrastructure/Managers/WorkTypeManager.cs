using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.WorkType;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers
{
    /// <summary>
    /// WorkType manager
    /// </summary>
    public class WorkTypeManager : IManagerBase<WorkType, WorkTypeDto>
    {
        private readonly IRepository<WorkType> _repository;
        private readonly IMapper _mapper;
        private readonly ICreateBase<WorkType, WorkTypeDto> _createOperation;
        private readonly IUpdateBase<WorkType, WorkTypeDto> _updateOperation;
        private readonly IDeleteBase<WorkType> _deleteOperation;
        private readonly ICreateWorkTypeValidator _createValidator;
        private readonly IUpdateWorkTypeValidator _updateValidator;
        private readonly IDeleteWorkTypeValidator _deleteValidator;

        /// <inheritdoc/>
        public WorkTypeManager(
            IRepository<WorkType> repository,
            IMapper mapper,
            ICreateBase<WorkType, WorkTypeDto> createOperation,
            IUpdateBase<WorkType, WorkTypeDto> updateOperation,
            IDeleteBase<WorkType> deleteOperation,
            ICreateWorkTypeValidator createValidator,
            IUpdateWorkTypeValidator updateValidator,
            IDeleteWorkTypeValidator deleteValidator)
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
        public IOperationResult Create(WorkTypeDto dto)
        {
            return _createOperation.Create(dto, _createValidator);
        }

        /// <inheritdoc/>
        public IOperationResult Delete(int id)
        {
            return _deleteOperation.Delete(id, _deleteValidator);
        }

        /// <inheritdoc/>
        public WorkTypeDto GetById(int id)
        {
            return _mapper.Map<WorkTypeDto>(_repository.GetById(id));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<WorkTypeDto> GetPageList(int skip, int take)
        {
            return _mapper.Map<IReadOnlyCollection<WorkTypeDto>>(_repository.GetPageList(skip, take));
        }

        /// <inheritdoc/>
        public IOperationResult Update(WorkTypeDto dto)
        {
            return _updateOperation.Update(dto, _updateValidator);
        }
    }
}
