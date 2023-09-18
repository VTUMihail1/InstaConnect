using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Comment;
using InstaConnect.Presentation.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/comments/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByUserIdAsync([FromRoute] string userId)
        {
            var response = await _commentService.GetAllByUserIdAsync(userId);

            return Ok(response);
        }

        // GET: api/comments/by-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-post/{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByPostIdAsync([FromRoute] string postId)
        {
            var response = await _commentService.GetAllByPostIdAsync(postId);

            return Ok(response);
        }

        // POST: api/comments
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] CommentAddDTO commentAddDTO)
        {
            var response = await _commentService.AddAsync(commentAddDTO);

            return this.HandleResponse(response);
        }

        // PUT: api/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] CommentUpdateDTO commentUpdateDTO)
        {
            var response = await _commentService.UpdateAsync(id, commentUpdateDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePostComment([FromRoute] string id)
        {
            var response = await _commentService.DeleteAsync(id);

            return this.HandleResponse(response);
        }
    }
}
