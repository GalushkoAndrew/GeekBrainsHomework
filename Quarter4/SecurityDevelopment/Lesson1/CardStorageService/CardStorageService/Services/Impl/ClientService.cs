using CardStorageService.Data;
using ClientServiceProtos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static ClientServiceProtos.ClientService;

namespace CardStorageService.Services.Impl
{
    public class ClientService : ClientServiceBase
    {

        #region Services

        private readonly IClientRepositoryService _clientRepositoryService;
        private readonly ILogger<ClientService> _logger;

        #endregion

        public ClientService(ILogger<ClientService> logger,
            IClientRepositoryService clientRepositoryService)
        {
            _clientRepositoryService = clientRepositoryService;
            _logger = logger;
        }

        public override Task<CreateClientResponse> Create(CreateClientRequest request, ServerCallContext context)
        {

            try
            {
                var clientId = _clientRepositoryService.Create(new Client
                {
                    Firstname = request.FirstName,
                    Surname = request.Surname,
                    Patronymic = request.Patronymic
                });

                var response = new CreateClientResponse
                {
                    ClientId = clientId,
                    ErrorCode = 0,
                    ErrorMessage = String.Empty
                };

                return Task.FromResult(response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create client error.");
                var response = new CreateClientResponse
                {
                    ClientId = -1,
                    ErrorCode = 912,
                    ErrorMessage = "Create clinet error."
                };

                return Task.FromResult(response);
            }

        }
    }
}
