using CardStorageService.Data;
using CardStorageService.Models;
using CardStorageService.Models.Requests;
using CardStorageService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CardStorageService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardRepositoryService _repository;

        public CardController(
            ILogger<CardController> logger,
            ICardRepositoryService repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateCardResponse), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateCardRequest request)
        {
            try
            {
                var cardId = _repository.Create(new Card
                {
                    ClientId = request.ClientId,
                    CardNo = request.CardNo,
                    Name = request.Name,
                    ExpDate = request.ExpDate,
                    CVV2 = request.CVV2
                });
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
            try
            {
                var result = _repository.Update(new Card
                {
                    Id = Guid.Parse(request.CardId),
                    ClientId = request.ClientId,
                    CardNo = request.CardNo,
                    Name = request.Name,
                    ExpDate = request.ExpDate,
                    CVV2 = request.CVV2
                });
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
        [ProducesResponseType(typeof(UpdateCardResponse), StatusCodes.Status200OK)]
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
                    Cards = cards.Select(card => new CardDto
                    {
                        CardId = card.Id,
                        CardNo = card.CardNo,
                        CVV2 = card.CVV2,
                        Name = card.Name,
                        ExpDate = card.ExpDate.ToString("MM/yy")
                    }).ToList()
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
                    Card = new CardDto
                    {
                        CardId = card.Id,
                        CardNo = card.CardNo,
                        CVV2 = card.CVV2,
                        Name = card.Name,
                        ExpDate = card.ExpDate.ToString("MM/yy")
                    }
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
