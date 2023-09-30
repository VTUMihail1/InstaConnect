using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Business.Models.Utilities;
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

            return Ok(response);
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

        // GET: api/post-likes/by-user-and-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user-and-post/{userId}/{postId}")]
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddAsync([FromBody] PostLikeAddDTO postLikeAddDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postLikeService.AddAsync(currentUserId, postLikeAddDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/post-likes/by-user-and-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("by-user-and-post/{userId}/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserIdAndPostIdAsync([FromRoute] string userId, [FromRoute] string postId)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postLikeService.DeleteByUserIdAndPostIdAsync(currentUserId, userId, postId);

            return this.HandleResponse(response);
        }

        // DELETE: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postLikeService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }
    }
}
