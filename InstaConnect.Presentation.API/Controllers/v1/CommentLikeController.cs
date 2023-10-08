using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Models.Utilities;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Presentation.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/comment-likes")]
    [ApiVersion("1.0")]
    public class CommentLikeController : ControllerBase
    {
        private readonly ICommentLikeService _commentLikeService;

        public CommentLikeController(ICommentLikeService commentLikeService)
        {
            _commentLikeService = commentLikeService;
        }

        // GET: api/v1/comment-likes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string userId = default,
            [FromQuery] string postId = default,
            [FromQuery][Range(InstaConnectModelConfigurations.PageMinLength, int.MaxValue)] int page = 1,
            [FromQuery][Range(InstaConnectModelConfigurations.AmountMinLength, int.MaxValue)] int amount = 18)
        {
            var response = await _commentLikeService.GetAllAsync(userId, postId, page, amount);

            return this.HandleResponse(response);
        }

        // GET: api/v1/comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _commentLikeService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        //GET: api/v1/comment-likes/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-post-comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user/{userId:alpha}/by-post-comment/{postCommentId:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserIdAndPostCommentIdAsync([FromRoute] string userId, [FromRoute] string postCommentId)
        {
            var response = await _commentLikeService.GetByUserIdAndPostCommentIdAsync(userId, postCommentId);

            return this.HandleResponse(response);
        }

        // POST: api/v1/comment-likes
        [Authorize]
        [AccessToken]
        [ValidateUser("UserId")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddAsync([FromBody] CommentLikeAddDTO commentLikeAddDTO)
        {
            var response = await _commentLikeService.AddAsync(commentLikeAddDTO);

            return this.HandleResponse(response);
        }

        //DELETE: api/v1/comment-likes/by-user/current/by-post-comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("by-user/current/by-post-comment/{postCommentId:alpha}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentUserIdAndPostCommentIdAsync([FromRoute] string postCommentId)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _commentLikeService.DeleteByUserIdAndPostCommentIdAsync(currentUserId, postCommentId);

            return this.HandleResponse(response);
        }

        //DELETE: api/v1/comment-likes/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-post-comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize(Roles = InstaConnectConstants.AdminRole)]
        [AccessToken]
        [HttpDelete("by-user/{userId:alpha}/by-post-comment/{postCommentId:alpha}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserIdAndPostCommentIdAsync([FromRoute] string userId, [FromRoute] string postCommentId)
        {
            var response = await _commentLikeService.DeleteByUserIdAndPostCommentIdAsync(userId, postCommentId);

            return this.HandleResponse(response);
        }

        //DELETE: api/v1/comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/current
        [Authorize]
        [AccessToken]
        [HttpDelete("{id:alpha}/by-user/current")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentUserIdAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _commentLikeService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }

        //DELETE: api/v1/comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize(Roles = InstaConnectConstants.AdminRole)]
        [AccessToken]
        [HttpDelete("{id:alpha}/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByUserIdAsync([FromRoute] string userId, [FromRoute] string id)
        {
            var response = await _commentLikeService.DeleteAsync(userId, id);

            return this.HandleResponse(response);
        }
    }
}
