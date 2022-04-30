using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations
{
    /// <inheritdoc/>
    public class CreateBase<TEntity, TDto> : ICreateBase<TEntity, TDto>
        where TEntity : IEntity
        where TDto : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        /// <inheritdoc/>
        public CreateBase(
            IRepository<TEntity> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public IOperationResult Create(
            TDto dto,
            IValidationService<TDto> validationService)
        {
            var operationResult = new OperationResult(validationService.ValidateEntity(dto));
            if (!operationResult.IsSuccess) {
                return operationResult;
            }

            _repository.Create(_mapper.Map<TEntity>(dto));
            return operationResult;
        }
    }
}
