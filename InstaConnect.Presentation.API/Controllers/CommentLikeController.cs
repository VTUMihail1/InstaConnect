using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/comment-likes")]
    [ApiController]
    public class CommentLikeController : ControllerBase
    {
        private readonly ICommentLikeService _commentLikeService;

        public CommentLikeController(ICommentLikeService commentLikeService)
        {
            _commentLikeService = commentLikeService;
        }

        // GET: api/comment-likes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] string userId = default, [FromQuery] string postId = default)
        {
            var response = await _commentLikeService.GetAllAsync(userId, postId);

            return Ok(response);
        }

        // GET: api/comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _commentLikeService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        // GET: api/comment-likes/by-post-comment-and-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-post-comment-and-user/{postCommentId}/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByPostCommentIdAndUserIdAsync([FromRoute] string postCommentId, [FromRoute] string userId)
        {
            var response = await _commentLikeService.GetByUserIdAndPostCommentIdAsync(postCommentId, userId);

            return this.HandleResponse(response);
        }

        // POST: api/comment-likes
        [Authorize]
        [AccessToken]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] CommentLikeAddDTO commentLikeAddDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _commentLikeService.AddAsync(currentUserId, commentLikeAddDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/comment-likes/by-post-comment-and-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("by-post-comment-and-user/{postCommentId}/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByPostCommentIdAndUserIdAsync([FromRoute] string postCommentId, [FromRoute] string userId)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _commentLikeService.DeleteByUserIdAndPostCommentIdAsync(currentUserId, postCommentId, userId);

            return this.HandleResponse(response);
        }

        // DELETE: api/comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _commentLikeService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }
    }
}
