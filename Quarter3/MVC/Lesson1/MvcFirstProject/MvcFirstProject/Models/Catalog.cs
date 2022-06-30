using System.Collections.Concurrent;

namespace MvcFirstProject.Models
{
    /// <summary>
    /// Catalog
    /// </summary>
    public class Catalog: ICatalog
    {
        private long index;

        public Catalog()
        {
            index = 0;
            SkuList = new ConcurrentDictionary<long, Sku>();
        }

        private ConcurrentDictionary<long, Sku> SkuList { get; set; }

        public long GetNewIndex()
            => Interlocked.Increment(ref index);

        public void Add(Sku sku, long ind)
        {
            SkuList.TryAdd(ind, sku);
        }

        public void RemoveSku(int id)
        {
            var skuToRemove = SkuList.Where(x => x.Value.Id == id);
            foreach (var item in skuToRemove) {
                SkuList.TryRemove(item.Key, out _);
            }
        }

        public Sku? Get(long index)
        {
            SkuList.TryGetValue(index, out Sku? sku);
            return sku;
        }

        public IReadOnlyList<Sku> GetList()
            => SkuList.Values.ToList().AsReadOnly();
    }
}
