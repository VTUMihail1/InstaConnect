using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Models.Utilities;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/post-comments")]
    [ApiController]
    public class PostCommentController : ControllerBase
    {
        private readonly IPostCommentService _postCommentService;

        public PostCommentController(IPostCommentService postCommentService)
        {
            _postCommentService = postCommentService;
        }

        // GET: api/post-comments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string userId = default,
            [FromQuery] string postId = default,
            [FromQuery] string postCommentId = default,
            [FromQuery][Range(InstaConnectModelConfigurations.PageMinLength, int.MaxValue)] int page = 1,
            [FromQuery][Range(InstaConnectModelConfigurations.AmountMinLength, int.MaxValue)] int amount = 18)
        {
            var response = await _postCommentService.GetAllAsync(userId, postId, postCommentId, page, amount);

            return this.HandleResponse(response);
        }

        // GET: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _postCommentService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }


        // POST: api/post-comments
        [Authorize]
        [AccessToken]
        [ValidateUser("UserId")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] PostCommentAddDTO postCommentAddDTO)
        {
            var response = await _postCommentService.AddAsync(postCommentAddDTO);

            return this.HandleResponse(response);
        }

        // PUT: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] PostCommentUpdateDTO postCommentUpdateDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postCommentService.UpdateAsync(currentUserId, id, postCommentUpdateDTO);

            return this.HandleResponse(response);
        }

        //DELETE: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/current
        [Authorize]
        [AccessToken]
        [HttpDelete("{id}/by-user/current")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentUserIdAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postCommentService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }

        //DELETE: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize(InstaConnectConstants.AdminRole)]
        [AccessToken]
        [HttpDelete("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserIdAsync([FromRoute] string userId, [FromRoute] string id)
        {
            var response = await _postCommentService.DeleteAsync(userId, id);

            return this.HandleResponse(response);
        }
    }
}
