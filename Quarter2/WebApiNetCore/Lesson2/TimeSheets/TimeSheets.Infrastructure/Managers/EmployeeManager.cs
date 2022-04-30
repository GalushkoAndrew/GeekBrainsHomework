using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Employee;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers
{
    /// <summary>
    /// Employee Manager
    /// </summary>
    public sealed class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICreateEmployeeValidator _createValidator;
        private readonly IUpdateEmployeeValidator _updateValidator;
        private readonly IDeleteEmployeeValidator _deleteValidator;
        private readonly IUpdateBase<Employee, EmployeeDto> _updateOperation;
        private readonly IDeleteBase<Employee> _deleteOperation;
        private readonly ICreateBase<Employee, EmployeeDto> _createOperation;

        /// <inheritdoc/>
        public EmployeeManager(
            IEmployeeRepository repository,
            IMapper mapper,
            ICreateEmployeeValidator createValidator,
            IUpdateEmployeeValidator updateValidator,
            IDeleteEmployeeValidator deleteValidator,
            IUpdateBase<Employee, EmployeeDto> updateOperation,
            IDeleteBase<Employee> deleteOperation,
            ICreateBase<Employee, EmployeeDto> createOperation)
        {
            _repository = repository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _deleteValidator = deleteValidator;
            _updateOperation = updateOperation;
            _deleteOperation = deleteOperation;
            _createOperation = createOperation;
        }

        /// <inheritdoc/>
        public IOperationResult Create(EmployeeDto dto)
        {
            return _createOperation.Create(dto, _createValidator);
        }

        /// <inheritdoc/>
        public IOperationResult Delete(int id)
        {
            return _deleteOperation.Delete(id, _deleteValidator);
        }

        /// <inheritdoc/>
        public EmployeeDto GetById(int id)
        {
            return _mapper.Map<EmployeeDto>(_repository.GetById(id));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<EmployeeDto> GetByTerm(string term)
        {
            return _mapper.Map<IReadOnlyCollection<EmployeeDto>>(_repository.GetByTerm(term));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<EmployeeDto> GetPageList(int skip, int take)
        {
            return _mapper.Map<IReadOnlyCollection<EmployeeDto>>(_repository.GetPageList(skip, take));
        }

        /// <inheritdoc/>
        public IOperationResult Update(EmployeeDto dto)
        {
            return _updateOperation.Update(dto, _updateValidator);
        }
    }
}
