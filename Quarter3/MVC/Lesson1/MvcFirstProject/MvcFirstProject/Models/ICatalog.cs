namespace MvcFirstProject.Models
{
    public interface ICatalog
    {
        void AddSku(Sku sku);

        IReadOnlyList<Sku> Get();

        Sku? Get(long index);

        void RemoveSku(int id);
    }
}
