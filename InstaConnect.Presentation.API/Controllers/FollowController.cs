using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Follow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/follows")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        // GET: api/follows/by-follower/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-follower/{followerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByFollowerIdAsync([FromRoute] string followerId)
        {
            var response = await _followService.GetAllByFollowerIdAsync(followerId);

            return Ok(response);
        }

        // GET: api/follows/by-following/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-following/{followingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByFollowingIdAsync([FromRoute] string followingId)
        {
            var response = await _followService.GetAllByFollowingIdAsync(followingId);

            return Ok(response);
        }

        // POST: api/follows
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] FollowAddDTO followAddDTO)
        {
            var response = await _followService.AddAsync(followAddDTO);

            return Ok(response);
        }

        // DELETE: api/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("{followerId}/{followingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string followerId, [FromRoute] string followingId)
        {
            var response = await _followService.DeleteAsync(followerId, followingId);

            return Ok(response);
        }
    }
}
