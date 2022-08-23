using CardStorageService.Data;
using System.Collections.Generic;

namespace CardStorageService.Services
{
    public interface ICardRepositoryService : IRepository<Card, string>
    {
        IList<Card> GetByClientId(int id);
    }
}
