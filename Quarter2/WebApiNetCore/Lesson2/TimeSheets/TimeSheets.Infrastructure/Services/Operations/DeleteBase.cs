using GeekBrains.Learn.TimeSheets.Domain.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations
{
    /// <inheritdoc/>
    public class DeleteBase<TEntity> : IDeleteBase<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;

        /// <inheritdoc/>
        public DeleteBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public IOperationResult Delete(
            int id,
            IValidationService<TEntity> validationService)
        {
            var entity = _repository.GetById(id);
            var operationResult = new OperationResult(validationService.ValidateEntity(entity));
            if (!operationResult.IsSuccess) {
                return operationResult;
            }

            _repository.Delete(entity);
            return operationResult;
        }
    }
}
