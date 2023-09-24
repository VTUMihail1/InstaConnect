using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.PostLike;
using InstaConnect.Presentation.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/post-likes/detailed
        [HttpGet("detailed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDetailedAsync()
        {
            var response = await _postLikeService.GetAllDetailedAsync();
            return Ok(response);
        }

        // GET: api/post-likes/detailed/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("detailed/by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDetailedByUserIdAsync([FromRoute] string userId)
        {
            var response = await _postLikeService.GetAllDetailedByUserIdAsync(userId);
            return Ok(response);
        }

        // GET: api/post-likes/detailed/by-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("detailed/by-post/{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDetailedByPostIdAsync([FromRoute] string postId)
        {
            var response = await _postLikeService.GetAllDetailedByPostIdAsync(postId);
            return Ok(response);
        }

        // GET: api/post-likes/detailed/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("detailed/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedByIdAsync([FromRoute] string id)
        {
            var response = await _postLikeService.GetDetailedByIdAsync(id);
            return this.HandleResponse(response);
        }

        // GET: api/post-likes/detailed/by-user-and-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpGet("detailed/by-user-and-post/{userId}/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedByPostIdAndUserIdAsync([FromRoute] string userId, [FromRoute] string postId)
        {
            var response = await _postLikeService.GetDetailedByPostIdAndUserIdAsync(userId, postId);

            return this.HandleResponse(response);
        }

        // GET: api/post-likes/detailed
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _postLikeService.GetAllAsync();
            return Ok(response);
        }

        // GET: api/post-likes/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByUserIdAsync([FromRoute] string userId)
        {
            var response = await _postLikeService.GetAllByUserIdAsync(userId);
            return Ok(response);
        }

        // GET: api/post-likes/by-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-post/{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByPostIdAsync([FromRoute] string postId)
        {
            var response = await _postLikeService.GetAllByPostIdAsync(postId);
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
        [Authorize]
        [HttpGet("by-user-and-post/{userId}/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByPostIdAndUserIdAsync([FromRoute] string userId, [FromRoute] string postId)
        {
            var response = await _postLikeService.GetByPostIdAndUserIdAsync(userId, postId);

            return this.HandleResponse(response);
        }

        // POST: api/post-likes
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] PostLikeAddDTO postLikeAddDTO)
        {
            var response = await _postLikeService.AddAsync(postLikeAddDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/post-likes/by-user-and-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("by-user-and-post/{userId}/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByPostIdAndUserIdAsync([FromRoute] string userId, [FromRoute] string postId)
        {
            var response = await _postLikeService.DeleteByPostIdAndUserIdAsync(userId, postId);

            return this.HandleResponse(response);
        }

        // DELETE: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var response = await _postLikeService.DeleteAsync(id);

            return this.HandleResponse(response);
        }
    }
}
