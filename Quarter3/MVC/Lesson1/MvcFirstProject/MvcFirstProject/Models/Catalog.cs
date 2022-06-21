using MvcFirstProject.Models.Mail;
using MvcFirstProject.Services;
using System.Collections.Concurrent;

namespace MvcFirstProject.Models
{
    /// <summary>
    /// Catalog
    /// </summary>
    public class Catalog: ICatalog
    {
        private long index;
        private readonly ISendMailService _mailService;

        public Catalog(ISendMailService mailService)
        {
            index = 0;
            SkuList = new ConcurrentDictionary<long, Sku>();
            _mailService = mailService;
        }

        private ConcurrentDictionary<long, Sku> SkuList { get; set; }

        public void AddSku(Sku sku)
        {
            var currentIndex = Interlocked.Increment(ref index);
            SkuList.AddOrUpdate(sku.Id, sku, (ind, old) => sku);
            var mailFields = new MailFields(
                "asp2022gb@rodion-m.ru",
                "3drtLSa1",
                "strateg-23@yandex.ru",
                "Notification",
                "New goods added",
                "smtp.beget.com",
                25);
            _mailService.Send(mailFields);
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
            => SkuList.Values.ToList().AsReadOnly();
    }
}
