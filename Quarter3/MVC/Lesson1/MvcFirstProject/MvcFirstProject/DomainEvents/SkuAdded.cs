using MvcFirstProject.Models;

namespace MvcFirstProject.DomainEvents
{
    public class SkuAdded : IDomainEvent
    {
        public Sku Sku { get; }
        public CancellationToken CancellationToken { get; }

        public SkuAdded(Sku sku, CancellationToken cancellationToken)
        {
            Sku = sku;
            CancellationToken = cancellationToken;
        }
    }
}
