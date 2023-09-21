using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Presentation.API.Extensions;
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

        // GET: api/comment-likes/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByUserIdAsync([FromRoute] string userId)
        {
            var response = await _commentLikeService.GetAllByUserIdAsync(userId);

            return Ok(response);
        }

        // GET: api/comment-likes/by-comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-comment/{commentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByCommentIdAsync([FromRoute] string commentId)
        {
            var response = await _commentLikeService.GetAllByCommentIdAsync(commentId);

            return Ok(response);
        }

        // POST: api/comment-likes
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] CommentLikeAddDTO commentLikeAddDTO)
        {
            var response = await _commentLikeService.AddAsync(commentLikeAddDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var response = await _commentLikeService.DeleteAsync(id);

            return this.HandleResponse(response);
        }
    }
}
