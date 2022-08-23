using CardStorageService.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CardStorageService.Services.Impl
{
    public class CardRepository : ICardRepositoryService
    {
        private readonly ILogger<CardRepository> _logger;
        private readonly CardStorageServiceDbContext _context;

        public CardRepository(ILogger<CardRepository> logger,
            CardStorageServiceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public string Create(Card data)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Id == data.ClientId);
            if (client == null)
            {
                throw new System.Exception("Client not found");
            }
            _context.Cards.Add(data);
            _context.SaveChanges();
            return data.Id.ToString();
        }

        public int Delete(string id)
        {
            _context.Cards.Remove(GetById(id));
            _context.SaveChanges();
            return 1;
        }

        public IList<Card> GetAll()
        {
            return _context.Cards.ToList();
        }

        public IList<Card> GetByClientId(int id)
        {
            return _context.Cards.Where(x => x.ClientId == id).ToList();
        }

        public Card GetById(string id)
        {
            return _context.Cards.Where(x => x.Id.ToString() == id).FirstOrDefault();
        }

        public int Update(Card data)
        {
            _context.Cards.Update(data);
            _context.SaveChanges();
            return 1;
        }
    }
}
