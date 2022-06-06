namespace MvcFirstProject.Models
{
    public interface ICatalog
    {
        void AddSku(Sku sku);
        IReadOnlyList<Sku> Get();
    }
}
