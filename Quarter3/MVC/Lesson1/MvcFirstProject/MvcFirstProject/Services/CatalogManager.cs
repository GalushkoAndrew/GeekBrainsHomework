using MvcFirstProject.Models;
using MvcFirstProject.Models.Mail;

namespace MvcFirstProject.Services
{
    public class CatalogManager : ICatalogManager
    {
        private readonly ICatalog _catalog;
        private readonly ISendMailService _mailService;

        public CatalogManager(ICatalog catalog,
            ISendMailService mailService)
        {
            _catalog = catalog;
            _mailService = mailService;
        }
        public void Create(Sku sku)
        {
            var currentIndex = _catalog.GetNewIndex();
            _catalog.Add(sku, currentIndex);
            _mailService.Send(GetMailFields());
        }

        public Sku? Get(long index)
            => _catalog.Get(index);

        public IReadOnlyList<Sku> GetList()
            => _catalog.GetList();

        public void Delete(int id)
            => _catalog.RemoveSku(id);

        private MailFields GetMailFields()
        {
            return new MailFields(
                from: "asp2022gb@rodion-m.ru",
                password: "3drtLSa1",
                to: "strateg-23@yandex.ru",
                subject: "Notification",
                body: "New goods added",
                host: "smtp.beget.com",
                port: 25);
        }
    }
}
