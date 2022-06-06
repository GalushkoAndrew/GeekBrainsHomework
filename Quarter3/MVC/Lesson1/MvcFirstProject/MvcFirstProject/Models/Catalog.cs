namespace MvcFirstProject.Models
{
    /// <summary>
    /// Catalog
    /// </summary>
    public class Catalog: ICatalog
    {
        private object syncObj = new();

        public Catalog()
        {
            SkuList = new List<Sku>();
        }

        private List<Sku> SkuList { get; set; }

        public void AddSku(Sku sku)
        {
            lock(syncObj) {
                SkuList.Add(sku);
            }
        }

        public IReadOnlyList<Sku> Get()
        {
            lock (syncObj) {
                return SkuList.AsReadOnly();
            }
        }
    }
}
