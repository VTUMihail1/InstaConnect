using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Presentation.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/messages
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _messageService.GetAllAsync();

            return Ok(response);
        }

        // GET: api/messages/by-sender/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-sender/{senderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBySenderIdAsync([FromRoute] string senderId)
        {
            var response = await _messageService.GetAllBySenderIdAsync(senderId);

            return Ok(response);
        }

        // GET: api/messages/by-receiver/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-receiver/{receiverId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByReceiverIdAsync([FromRoute] string receiverId)
        {
            var response = await _messageService.GetAllByReceiverIdAsync(receiverId);

            return Ok(response);
        }

        // GET: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _messageService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        // GET: api/messages/by-sender-and-receiver/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-sender-and-receiver/{senderId}/{receiverId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBySenderIdAndReceiverIdAsync([FromRoute] string senderId, [FromRoute] string receiverId)
        {
            var response = await _messageService.GetBySenderIdAndReceiverIdAsync(senderId, receiverId);

            return this.HandleResponse(response);
        }

        // POST: api/messages
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] MessageAddDTO messageAddDTO)
        {
            var response = await _messageService.AddAsync(messageAddDTO);

            return this.HandleResponse(response);
        }

        // PUT: api/messages
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] MessageUpdateDTO messageUpdateDTO)
        {
            var response = await _messageService.UpdateAsync(id, messageUpdateDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/messages/by-sender-and-receiver/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("by-sender-and-receiver/{senderId}/{receiverId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBySenderIdAndReceiverIdAsync([FromRoute] string senderId, [FromRoute] string receiverId)
        {
            var response = await _messageService.DeleteBySenderIdAndReceiverIdAsync(senderId, receiverId);

            return this.HandleResponse(response);
        }

        // DELETE: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var response = await _messageService.DeleteAsync(id);

            return this.HandleResponse(response);
        }
    }
}
