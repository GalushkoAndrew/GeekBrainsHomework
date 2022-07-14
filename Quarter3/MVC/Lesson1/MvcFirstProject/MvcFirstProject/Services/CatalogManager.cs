using MvcFirstProject.DomainEvents;
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

        public void Create(Sku sku, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var currentIndex = _catalog.GetNewIndex();
            _catalog.Add(sku, currentIndex, cancellationToken);
            DomainEventsManager.Raise(new SkuAdded(sku, cancellationToken));
            _logger.LogInformation("Good was added: {name}", sku.Name ?? "");
        }

        public Sku? Get(long index)
            => _catalog.Get(index);

        public IReadOnlyList<Sku> GetList()
            => _catalog.GetList();

        public void Delete(int id)
            => _catalog.RemoveSku(id);
    }
}
