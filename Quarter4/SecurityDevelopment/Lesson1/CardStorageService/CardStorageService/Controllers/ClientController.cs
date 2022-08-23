using CardStorageService.Data;
using CardStorageService.Models.Requests;
using CardStorageService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CardStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientRepositoryService _repository;

        public ClientController(
            ILogger<ClientController> logger,
            IClientRepositoryService repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateClientResponse), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateClientRequest request)
        {
            try
            {
                var clientId = _repository.Create(new Client
                {
                    Firstname = request.Firstname,
                    Surname = request.Surname,
                    Patronymic = request.Patronymic
                });
                return Ok(new CreateClientResponse
                {
                    ClientId = clientId,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create client error");
                return Ok(new CreateClientResponse
                {
                    ErrorCode = 1,
                    ErrorMessage = "Create client error"
                });
            }
        }
    }
}
