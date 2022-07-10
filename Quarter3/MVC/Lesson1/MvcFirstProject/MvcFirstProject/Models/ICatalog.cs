namespace MvcFirstProject.Models
{
    public interface ICatalog
    {
        void Add(Sku sku, long ind, CancellationToken cancellationToken = default);

        IReadOnlyList<Sku> GetList();

        Sku? Get(long index);

        void RemoveSku(int id);

        long GetNewIndex();
    }
}
