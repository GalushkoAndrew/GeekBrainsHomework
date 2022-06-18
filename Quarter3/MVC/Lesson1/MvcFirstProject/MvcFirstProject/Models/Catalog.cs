using System;
using System.Collections.Concurrent;

namespace MvcFirstProject.Models
{
    /// <summary>
    /// Catalog
    /// </summary>
    public class Catalog: ICatalog
    {
        private object syncObj = new();
        private long index;

        public Catalog()
{
            index = 0;
            SkuList = new ConcurrentDictionary<long, Sku>();
        }

        private ConcurrentDictionary<long, Sku> SkuList { get; set; }

        public void AddSku(Sku sku)
        {
            var currentIndex = Interlocked.Increment(ref index);
            //SkuList.AddOrUpdate(currentIndex, sku, (ind, old) => old);
            SkuList.AddOrUpdate(sku.Id, sku, (ind, old) => sku);
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

        public IReadOnlyList<Sku> Get()
            => SkuList.Select(x => x.Value).ToList().AsReadOnly();
    }
}
