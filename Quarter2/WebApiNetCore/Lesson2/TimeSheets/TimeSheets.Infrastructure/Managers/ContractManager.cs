using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Contract;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers
{
    /// <summary>
    /// Contract manager
    /// </summary>
    public class ContractManager : IManagerBase<Contract, ContractDto>
    {
        private readonly IRepository<Contract> _repository;
        private readonly IMapper _mapper;
        private readonly ICreateBase<Contract, ContractDto> _createOperation;
        private readonly IUpdateBase<Contract, ContractDto> _updateOperation;
        private readonly IDeleteBase<Contract> _deleteOperation;
        private readonly ICreateContractValidator _createValidator;
        private readonly IUpdateContractValidator _updateValidator;
        private readonly IDeleteContractValidator _deleteValidator;

        /// <inheritdoc/>
        public ContractManager(
            IRepository<Contract> repository,
            IMapper mapper,
            ICreateBase<Contract, ContractDto> createOperation,
            IUpdateBase<Contract, ContractDto> updateOperation,
            IDeleteBase<Contract> deleteOperation,
            ICreateContractValidator createValidator,
            IUpdateContractValidator updateValidator,
            IDeleteContractValidator deleteValidator)
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
        public IOperationResult Create(ContractDto dto)
        {
            return _createOperation.Create(dto, _createValidator);
        }

        /// <inheritdoc/>
        public IOperationResult Delete(int id)
        {
            return _deleteOperation.Delete(id, _deleteValidator);
        }

        /// <inheritdoc/>
        public ContractDto GetById(int id)
        {
            return _mapper.Map<ContractDto>(_repository.GetById(id));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<ContractDto> GetPageList(int skip, int take)
        {
            return _mapper.Map<IReadOnlyCollection<ContractDto>>(_repository.GetPageList(skip, take));
        }

        /// <inheritdoc/>
        public IOperationResult Update(ContractDto dto)
        {
            return _updateOperation.Update(dto, _updateValidator);
        }
    }
}
