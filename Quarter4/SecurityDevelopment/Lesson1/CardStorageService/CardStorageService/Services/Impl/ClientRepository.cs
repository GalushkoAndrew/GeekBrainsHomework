using CardStorageService.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CardStorageService.Services.Impl
{
    public class ClientRepository : IClientRepositoryService
    {
        private readonly ILogger<ClientRepository> _logger;
        private readonly CardStorageServiceDbContext _context;

        public ClientRepository(
            ILogger<ClientRepository> logger,
            CardStorageServiceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public int Create(Client data)
        {
            _context.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public int Delete(int id)
        {
            _context.Clients.Remove(GetById(id));
            _context.SaveChanges();
            return 1;
        }

        public IList<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client GetById(int id)
        {
            return _context.Clients.Where(x => x.Id == id).FirstOrDefault();
        }

        public int Update(Client data)
        {
            _context.Clients.Update(data);
            _context.SaveChanges();
            return 1;
        }
    }
}
