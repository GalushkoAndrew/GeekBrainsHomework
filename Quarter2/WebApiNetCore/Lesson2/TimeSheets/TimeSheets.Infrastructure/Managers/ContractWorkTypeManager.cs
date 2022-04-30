using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.ContractWorkType;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers
{
    /// <summary>
    /// ContractWorkType manager
    /// </summary>
    public class ContractWorkTypeManager : IManagerBase<ContractWorkType, ContractWorkTypeDto>
    {
        private readonly IRepository<ContractWorkType> _repository;
        private readonly IMapper _mapper;
        private readonly ICreateBase<ContractWorkType, ContractWorkTypeDto> _createOperation;
        private readonly IUpdateBase<ContractWorkType, ContractWorkTypeDto> _updateOperation;
        private readonly IDeleteBase<ContractWorkType> _deleteOperation;
        private readonly ICreateContractWorkTypeValidator _createValidator;
        private readonly IUpdateContractWorkTypeValidator _updateValidator;
        private readonly IDeleteContractWorkTypeValidator _deleteValidator;

        /// <inheritdoc/>
        public ContractWorkTypeManager(
            IRepository<ContractWorkType> repository,
            IMapper mapper,
            ICreateBase<ContractWorkType, ContractWorkTypeDto> createOperation,
            IUpdateBase<ContractWorkType, ContractWorkTypeDto> updateOperation,
            IDeleteBase<ContractWorkType> deleteOperation,
            ICreateContractWorkTypeValidator createValidator,
            IUpdateContractWorkTypeValidator updateValidator,
            IDeleteContractWorkTypeValidator deleteValidator)
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
        public IOperationResult Create(ContractWorkTypeDto dto)
        {
            return _createOperation.Create(dto, _createValidator);
        }

        /// <inheritdoc/>
        public IOperationResult Delete(int id)
        {
            return _deleteOperation.Delete(id, _deleteValidator);
        }

        /// <inheritdoc/>
        public ContractWorkTypeDto GetById(int id)
        {
            return _mapper.Map<ContractWorkTypeDto>(_repository.GetById(id));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<ContractWorkTypeDto> GetPageList(int skip, int take)
        {
            return _mapper.Map<IReadOnlyCollection<ContractWorkTypeDto>>(_repository.GetPageList(skip, take));
        }

        /// <inheritdoc/>
        public IOperationResult Update(ContractWorkTypeDto dto)
        {
            return _updateOperation.Update(dto, _updateValidator);
        }
    }
}
