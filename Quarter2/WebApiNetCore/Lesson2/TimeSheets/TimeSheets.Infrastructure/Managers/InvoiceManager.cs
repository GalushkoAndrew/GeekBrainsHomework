using System.Collections.Generic;
using AutoMapper;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Requests.Invoice;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers
{
    /// <summary>
    /// Invoice manager
    /// </summary>
    public class InvoiceManager : IManagerBase<Invoice, InvoiceDto>
    {
        private readonly IRepository<Invoice> _repository;
        private readonly IMapper _mapper;
        private readonly ICreateBase<Invoice, InvoiceDto> _createOperation;
        private readonly IUpdateBase<Invoice, InvoiceDto> _updateOperation;
        private readonly IDeleteBase<Invoice> _deleteOperation;
        private readonly ICreateInvoiceValidator _createValidator;
        private readonly IUpdateInvoiceValidator _updateValidator;
        private readonly IDeleteInvoiceValidator _deleteValidator;

        /// <inheritdoc/>
        public InvoiceManager(
            IRepository<Invoice> repository,
            IMapper mapper,
            ICreateBase<Invoice, InvoiceDto> createOperation,
            IUpdateBase<Invoice, InvoiceDto> updateOperation,
            IDeleteBase<Invoice> deleteOperation,
            ICreateInvoiceValidator createValidator,
            IUpdateInvoiceValidator updateValidator,
            IDeleteInvoiceValidator deleteValidator)
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
        public IOperationResult Create(InvoiceDto dto)
        {
            return _createOperation.Create(dto, _createValidator);
        }

        /// <inheritdoc/>
        public IOperationResult Delete(int id)
        {
            return _deleteOperation.Delete(id, _deleteValidator);
        }

        /// <inheritdoc/>
        public InvoiceDto GetById(int id)
        {
            return _mapper.Map<InvoiceDto>(_repository.GetById(id));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<InvoiceDto> GetPageList(int skip, int take)
        {
            return _mapper.Map<IReadOnlyCollection<InvoiceDto>>(_repository.GetPageList(skip, take));
        }

        /// <inheritdoc/>
        public IOperationResult Update(InvoiceDto dto)
        {
            return _updateOperation.Update(dto, _updateValidator);
        }
    }
}
