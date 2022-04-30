using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Work;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers
{
    /// <summary>
    /// Work manager
    /// </summary>
    public class WorkManager : IManagerBase<Work, WorkDto>
    {
        private readonly IRepository<Work> _repository;
        private readonly IMapper _mapper;
        private readonly ICreateBase<Work, WorkDto> _createOperation;
        private readonly IUpdateBase<Work, WorkDto> _updateOperation;
        private readonly IDeleteBase<Work> _deleteOperation;
        private readonly ICreateWorkValidator _createValidator;
        private readonly IUpdateWorkValidator _updateValidator;
        private readonly IDeleteWorkValidator _deleteValidator;

        /// <inheritdoc/>
        public WorkManager(
            IRepository<Work> repository,
            IMapper mapper,
            ICreateBase<Work, WorkDto> createOperation,
            IUpdateBase<Work, WorkDto> updateOperation,
            IDeleteBase<Work> deleteOperation,
            ICreateWorkValidator createValidator,
            IUpdateWorkValidator updateValidator,
            IDeleteWorkValidator deleteValidator)
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
        public IOperationResult Create(WorkDto dto)
        {
            return _createOperation.Create(dto, _createValidator);
        }

        /// <inheritdoc/>
        public IOperationResult Delete(int id)
        {
            return _deleteOperation.Delete(id, _deleteValidator);
        }

        /// <inheritdoc/>
        public WorkDto GetById(int id)
        {
            return _mapper.Map<WorkDto>(_repository.GetById(id));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<WorkDto> GetPageList(int skip, int take)
        {
            return _mapper.Map<IReadOnlyCollection<WorkDto>>(_repository.GetPageList(skip, take));
        }

        /// <inheritdoc/>
        public IOperationResult Update(WorkDto dto)
        {
            return _updateOperation.Update(dto, _updateValidator);
        }
    }
}
