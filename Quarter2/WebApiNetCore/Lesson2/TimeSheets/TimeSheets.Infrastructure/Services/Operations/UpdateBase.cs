using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations
{
    /// <inheritdoc/>
    public class UpdateBase<TEntity, TDto> : IUpdateBase<TEntity, TDto>
        where TEntity : IEntity
        where TDto : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        /// <inheritdoc/>
        public UpdateBase(
            IRepository<TEntity> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public IOperationResult Update(
            TDto dto,
            IValidationService<TDto> validationService)
        {
            var operationResult = new OperationResult(validationService.ValidateEntity(dto));
            if (!operationResult.IsSuccess) {
                return operationResult;
            }

            _repository.Update(_mapper.Map<TEntity>(dto));
            return operationResult;
        }
    }
}
