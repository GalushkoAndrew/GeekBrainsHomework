using ClinicService.Data;

namespace ClinicService.Services.Impl
{
    public class PetRepository : IPetRepository
    {

        #region Serives

        private readonly ClinicServiceDbContext _dbContext;
        private readonly ILogger<PetRepository> _logger;

        #endregion

        #region Constructors

        public PetRepository(ClinicServiceDbContext dbContext,
            ILogger<PetRepository> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        #endregion

        public int Add(Pet item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pet item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Pet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pet? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pet item)
        {
            throw new NotImplementedException();
        }
    }
}
