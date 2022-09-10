using AutoMapper;
using CardStorageService.Data;
using CardStorageService.Models;
using CardStorageService.Models.Requests;
using CardStorageService.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CardStorageService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardRepositoryService _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCardRequest> _createCardRequestValidator;
        private readonly IValidator<UpdateCardRequest> _updateCardRequestValidator;

        public CardController(
            ILogger<CardController> logger,
            ICardRepositoryService repository,
            IMapper mapper,
            IValidator<CreateCardRequest> createCardRequestValidator,
            IValidator<UpdateCardRequest> updateCardRequestValidator)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _createCardRequestValidator = createCardRequestValidator;
            _updateCardRequestValidator = updateCardRequestValidator;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateCardResponse), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateCardRequest request)
        {
            var validationResult = _createCardRequestValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var cardId = _repository.Create(_mapper.Map<Card>(request));
                return Ok(new CreateCardResponse
                {
                    CardId = cardId.ToString()
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create card error");
                return Ok(new CreateCardResponse
                {
                    ErrorCode = 2,
                    ErrorMessage = "Create card error"
                });
            }
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(UpdateCardResponse), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] UpdateCardRequest request)
        {
            var validationResult = _updateCardRequestValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            try
            {
                var result = _repository.Update(_mapper.Map<Card>(request));
                return Ok(new UpdateCardResponse
                {
                    Count = result
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Update card error");
                return Ok(new UpdateCardResponse
                {
                    ErrorCode = 5,
                    ErrorMessage = "Update card error"
                });
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(DeleteCardResponse), StatusCodes.Status200OK)]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = _repository.Delete(id);
                return Ok(new DeleteCardResponse()
                {
                    Count = result
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Delete card error");
                return Ok(new DeleteCardResponse
                {
                    ErrorCode = 6,
                    ErrorMessage = "Delete card error"
                });
            }
        }

        [HttpGet("get-by-client-id/{clientId}")]
        [ProducesResponseType(typeof(GetCardsResponse), StatusCodes.Status200OK)]
        public IActionResult GetByClientId(int clientId)
        {
            try
            {
                var cards = _repository.GetByClientId(clientId);
                return Ok(new GetCardsResponse
                {
                    Cards = _mapper.Map<List<CardDto>>(cards)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get cards error.");
                return Ok(new GetCardsResponse
                {
                    ErrorCode = 3,
                    ErrorMessage = "Get cards error."
                });
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(GetCardsResponse), StatusCodes.Status200OK)]
        public IActionResult Get(string id)
        {
            try
            {
                var card = _repository.GetById(id);
                if (card == null)
                {
                    throw new Exception("Card not found");
                }
                return Ok(new GetCardResponse
                {
                    Card = _mapper.Map<CardDto>(card)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get card error.");
                return Ok(new GetCardResponse
                {
                    ErrorCode = 4,
                    ErrorMessage = "Get card error."
                });
            }
        }
    }
}
