using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Like;
using InstaConnect.Presentation.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/likes")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        // GET: api/likes/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByUserIdAsync([FromRoute] string userId)
        {
            var response = await _likeService.GetAllByUserIdAsync(userId);

            return Ok(response);
        }

        // GET: api/likes/by-post/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-post/{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByPostIdAsync([FromRoute] string postId)
        {
            var response = await _likeService.GetAllByPostIdAsync(postId);

            return Ok(response);
        }

        // POST: api/likes
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromRoute] LikeAddDTO likeAddDTO)
        {
            var response = await _likeService.AddAsync(likeAddDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
        [Authorize]
        [HttpDelete("{userId}/{postId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string userId, [FromRoute] string postId)
        {
            var response = await _likeService.DeleteAsync(userId, postId);

            return this.HandleResponse(response);
        }
    }
}
