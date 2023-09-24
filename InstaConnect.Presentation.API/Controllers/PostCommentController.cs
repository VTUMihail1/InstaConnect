using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Presentation.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _postCommentService.GetAllAsync();

            return Ok(response);
        }

        // GET: api/post-comments/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByUserIdAsync([FromRoute] string userId)
        {
            var response = await _postCommentService.GetAllByUserIdAsync(userId);

            return Ok(response);
        }

        // GET: api/post-comments/by-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-post/{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByPostIdAsync([FromRoute] string postId)
        {
            var response = await _postCommentService.GetAllByPostIdAsync(postId);

            return Ok(response);
        }

        // GET: api/post-comments/by-parent-comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-parent-comment/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByParentIdAsync([FromRoute] string id)
        {
            var response = await _postCommentService.GetAllByParentIdAsync(id);

            return Ok(response);
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] PostCommentAddDTO postCommentAddDTO)
        {
            var response = await _postCommentService.AddAsync(postCommentAddDTO);

            return this.HandleResponse(response);
        }

        // PUT: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] PostCommentUpdateDTO postCommentUpdateDTO)
        {
            var response = await _postCommentService.UpdateAsync(id, postCommentUpdateDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/post-comment/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var response = await _postCommentService.DeleteAsync(id);

            return this.HandleResponse(response);
        }
    }
}
