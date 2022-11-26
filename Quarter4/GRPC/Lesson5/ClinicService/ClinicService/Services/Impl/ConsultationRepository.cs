using ClinicService.Data;

namespace ClinicService.Services.Impl
{
    public class ConsultationRepository : IConsultationRepository
    {

        #region Serives

        private readonly ClinicServiceDbContext _dbContext;
        private readonly ILogger<ConsultationRepository> _logger;

        #endregion

        #region Constructors

        public ConsultationRepository(ClinicServiceDbContext dbContext,
            ILogger<ConsultationRepository> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        #endregion

        public int Add(Consultation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Consultation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Consultation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Consultation? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Consultation item)
        {
            throw new NotImplementedException();
        }
    }
}
