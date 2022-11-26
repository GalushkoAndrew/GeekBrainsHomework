using ClinicService.Data;
using ClinicServiceProtos;
using Grpc.Core;
using static ClinicServiceProtos.ClinicClientService;

namespace ClinicService.Services.Impl
{
    public class ClinicClientService : ClinicClientServiceBase
    {
        #region Serives

        private readonly ClinicServiceDbContext _dbContext;
        private readonly ILogger<ClinicClientService> _logger;

        #endregion

        #region Constructors

        public ClinicClientService(ClinicServiceDbContext dbContext,
            ILogger<ClinicClientService> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        #endregion

        public override Task<ClinicServiceProtos.CreateClientResponse> CreateClient(ClinicServiceProtos.CreateClientRequest request, ServerCallContext context)
        {
            var client = new Client
            {
                Document = request.Document,
                Surname = request.Surname,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic
            };

            _dbContext.Clients.Add(client);

            _dbContext.SaveChanges();

            var response = new CreateClientResponse
            {
                ClientId = client.ClientId
            };

            return Task.FromResult(response);
        }

        public override Task<GetClientsResponse> GetClients(GetClientsRequest request, ServerCallContext context)
        {
            var response = new GetClientsResponse();

            response.Clients.AddRange(_dbContext.Clients.Select(client => new ClientResponse
            {
                ClientId = client.ClientId,
                Document = client.Document,
                FirstName = client.FirstName,
                Patronymic = client.Patronymic,
                Surname = client.Surname
            }).ToList());

            return Task.FromResult(response);
        }


    }
}
