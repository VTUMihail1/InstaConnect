using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostCommentLike;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Presentation.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/post-comment-likes")]
    [ApiVersion("1.0")]
    public class PostCommentLikeController : ControllerBase
    {
        private readonly IPostCommentLikeService _postCommentLikeService;

        public PostCommentLikeController(IPostCommentLikeService postCommentLikeService)
        {
            _postCommentLikeService = postCommentLikeService;
        }

        // GET: api/v1/post-comment-likes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string userId = default,
            [FromQuery] string postId = default,
            [FromQuery][Range(InstaConnectModelConfigurations.PageMinLength, int.MaxValue)] int page = 1,
            [FromQuery][Range(InstaConnectModelConfigurations.AmountMinLength, int.MaxValue)] int amount = 18)
        {
            var response = await _postCommentLikeService.GetAllAsync(userId, postId, page, amount);

            return this.HandleResponse(response);
        }

        // GET: api/v1/post-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _postCommentLikeService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        //GET: api/v1/post-comment-likes/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-post-comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user/{userId}/by-post-comment/{postCommentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserIdAndPostCommentIdAsync([FromRoute] string userId, [FromRoute] string postCommentId)
        {
            var response = await _postCommentLikeService.GetByUserIdAndPostCommentIdAsync(userId, postCommentId);

            return this.HandleResponse(response);
        }

        // POST: api/v1/post-comment-likes
        [Authorize]
        [AccessToken]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddAsync([FromBody] PostCommentLikeAddDTO postCommentLikeAddDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postCommentLikeService.AddAsync(currentUserId, postCommentLikeAddDTO);

            return this.HandleResponse(response);
        }

        //DELETE: api/v1/post-comment-likes/by-user/current/by-post-comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("by-user/current/by-post-comment/{postCommentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentUserIdAndPostCommentIdAsync([FromRoute] string postCommentId)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postCommentLikeService.DeleteByUserIdAndPostCommentIdAsync(currentUserId, postCommentId);

            return this.HandleResponse(response);
        }

        //DELETE: api/v1/post-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/current
        [Authorize]
        [AccessToken]
        [HttpDelete("{id}/by-user/current")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentUserIdAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _postCommentLikeService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }
    }
}
