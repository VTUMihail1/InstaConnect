using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Models.Utilities;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/post-likes")]
    [ApiController]
    public class PostLikeController : ControllerBase
    {
        private readonly IPostLikeService _postLikeService;

        public PostLikeController(IPostLikeService postLikeService)
        {
            _postLikeService = postLikeService;
        }

        // GET: api/post-likes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string userId = default,
            [FromQuery] string postId = default,
            [FromQuery][Range(InstaConnectModelConfigurations.PageMinLength, int.MaxValue)] int page = 1,
            [FromQuery][Range(InstaConnectModelConfigurations.AmountMinLength, int.MaxValue)] int amount = 18)
        {
            var response = await _postLikeService.GetAllAsync(userId, postId, page, amount);

            return this.HandleResponse(response);
        }

        // GET: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _postLikeService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        //GET: api/post-likes/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user/{userId}/by-post/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserIdAndPostIdAsync([FromRoute] string userId, [FromRoute] string postId)
        {
            var response = await _postLikeService.GetByUserIdAndPostIdAsync(userId, postId);

            return this.HandleResponse(response);
        }

        // POST: api/post-likes
        [Authorize]
        [AccessToken]
        [ValidateUser("UserId")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddAsync([FromBody] PostLikeAddDTO postLikeAddDTO)
        {
            var response = await _postLikeService.AddAsync(postLikeAddDTO);

            return this.HandleResponse(response);
        }

        //DELETE: api/post-likes/by-user/current/by-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("by-user/current/by-post/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentUserIdAndPostIdAsync([FromRoute] string postId)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postLikeService.DeleteByUserIdAndPostIdAsync(currentUserId, postId);

            return this.HandleResponse(response);
        }

        //DELETE: api/post-likes/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize(InstaConnectConstants.AdminRole)]
        [AccessToken]
        [HttpDelete("by-user/{userId}/by-post/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserIdAndPostIdAsync([FromRoute] string userId, [FromRoute] string postId)
        {
            var response = await _postLikeService.DeleteByUserIdAndPostIdAsync(userId, postId);

            return this.HandleResponse(response);
        }

        //DELETE: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/current
        [Authorize]
        [AccessToken]
        [HttpDelete("{id}/by-user/current")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentUserIdAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postLikeService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }

        //DELETE: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize(InstaConnectConstants.AdminRole)]
        [AccessToken]
        [HttpDelete("{id}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserIdAsync([FromRoute] string userId, [FromRoute] string id)
        {
            var response = await _postLikeService.DeleteAsync(userId, id);

            return this.HandleResponse(response);
        }
    }
}
