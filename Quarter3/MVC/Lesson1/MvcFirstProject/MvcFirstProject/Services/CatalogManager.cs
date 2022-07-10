using MvcFirstProject.Models;

namespace MvcFirstProject.Services
{
    public class CatalogManager : ICatalogManager
    {
        private readonly ICatalog _catalog;
        private readonly ISendMailService _mailService;
        private readonly ILogger _logger;

        public CatalogManager(ICatalog catalog,
            ISendMailService mailService,
            ILogger<CatalogManager> logger)
        {
            _catalog = catalog;
            _mailService = mailService;
            _logger = logger;
        }
        public void Create(Sku sku)
        {
            var currentIndex = _catalog.GetNewIndex();
            _catalog.Add(sku, currentIndex);
            _logger.LogInformation("Good was added: {name}", sku.Name ?? "");
            _mailService.Send("Notification", "New goods added");
        }

        public async Task CreateAsync(Sku sku, CancellationToken cancellationToken)
        {
            ThrowCanceledException(cancellationToken);
            var currentIndex = _catalog.GetNewIndex();
            _catalog.Add(sku, currentIndex, cancellationToken);
            _logger.LogInformation("Good was added: {name}", sku.Name ?? "");
            await _mailService.SendAsync("Notification", "New goods added", cancellationToken);
        }

        public Sku? Get(long index)
            => _catalog.Get(index);

        public IReadOnlyList<Sku> GetList()
            => _catalog.GetList();

        public void Delete(int id)
            => _catalog.RemoveSku(id);

        private void ThrowCanceledException(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) {
                throw new OperationCanceledException(cancellationToken);
            }
        }
    }
}
