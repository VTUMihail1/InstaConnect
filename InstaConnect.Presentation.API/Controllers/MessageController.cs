using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Data.Models.Utilities;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
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

        // GET: api/messages/by-sender/current/by-receiver/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpGet("by-sender/current/by-receiver/{receiverId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBySenderIdAndReceiverIdAsync([FromRoute] string receiverId)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _messageService.GetAllBySenderIdAndReceiverIdAsync(currentUserId, receiverId);

            return this.HandleResponse(response);
        }

        // GET: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _messageService.GetByIdAsync(currentUserId, id);

            return this.HandleResponse(response);
        }

        // POST: api/messages
        [Authorize]
        [AccessToken]
        [ValidateUser("SenderId")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddAsync([FromBody] MessageAddDTO messageAddDTO)
        {
            var response = await _messageService.AddAsync(messageAddDTO);

            return this.HandleResponse(response);
        }

        // PUT: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] MessageUpdateDTO messageUpdateDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _messageService.UpdateAsync(currentUserId, id, messageUpdateDTO);

            return this.HandleResponse(response);
        }

        //DELETE: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/current
        [Authorize]
        [AccessToken]
        [HttpDelete("{id}/by-user/current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentUserIdAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _messageService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }

        //DELETE: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize(InstaConnectConstants.AdminRole)]
        [AccessToken]
        [HttpDelete("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserIdAsync([FromRoute] string userId, [FromRoute] string id)
        {
            var response = await _messageService.DeleteAsync(userId, id);

            return this.HandleResponse(response);
        }
    }
}
