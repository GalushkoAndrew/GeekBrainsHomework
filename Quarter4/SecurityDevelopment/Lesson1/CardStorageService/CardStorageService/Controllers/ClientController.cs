using AutoMapper;
using CardStorageService.Data;
using CardStorageService.Models.Requests;
using CardStorageService.Models.Validators;
using CardStorageService.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CardStorageService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientRepositoryService _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateClientRequest> _createClientRequestValidator;

        public ClientController(
            ILogger<ClientController> logger,
            IClientRepositoryService repository,
            IMapper mapper,
            IValidator<CreateClientRequest> createClientRequestValidator)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _createClientRequestValidator = createClientRequestValidator;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateClientResponse), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateClientRequest request)
        {
            var validationResult = _createClientRequestValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var clientId = _repository.Create(_mapper.Map<Client>(request));
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
