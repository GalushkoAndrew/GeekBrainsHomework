using MvcFirstProject.Models;

namespace MvcFirstProject.Services
{
    public interface ICatalogManager
    {
        void Create(Sku sku, CancellationToken cancellationToken);
        void Delete(int id);
        Sku? Get(long index);
        IReadOnlyList<Sku> GetList();
    }
}
