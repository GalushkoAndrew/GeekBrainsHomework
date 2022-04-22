using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers
{
    /// <summary>
    /// Employee Manager
    /// </summary>
    public sealed class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        /// <inheritdoc/>
        public EmployeeManager(
            IEmployeeRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public void Create(EmployeeDto entity)
        {
            _repository.Create(_mapper.Map<Employee>(entity));
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            var entity = _repository.GetById(id);
            _repository.Delete(entity);
        }

        /// <inheritdoc/>
        public EmployeeDto GetById(int id)
        {
            return _mapper.Map<EmployeeDto>(_repository.GetById(id));
        }

        /// <inheritdoc/>
        public ICollection<EmployeeDto> GetByTerm(string term)
        {
            return _mapper.Map<ICollection<EmployeeDto>>(_repository.GetByTerm(term));
        }

        /// <inheritdoc/>
        public ICollection<EmployeeDto> GetPageList(int skip, int take)
        {
            return _mapper.Map<ICollection<EmployeeDto>>(_repository.GetPageList(skip, take));
        }

        /// <inheritdoc/>
        public void Update(EmployeeDto entity)
        {
            _repository.Update(_mapper.Map<Employee>(entity));
        }
    }
}
