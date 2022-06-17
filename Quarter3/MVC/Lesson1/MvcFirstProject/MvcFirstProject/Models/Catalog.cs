namespace MvcFirstProject.Models
{
    /// <summary>
    /// Catalog
    /// </summary>
    public class Catalog
    {
        public Catalog()
        {
            SkuList = new List<Sku>();
        }

        public List<Sku> SkuList { get; set; }
    }
}
