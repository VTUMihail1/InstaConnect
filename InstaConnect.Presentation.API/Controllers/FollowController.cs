using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Presentation.API.Extensions;
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

        // GET: api/follows/detailed
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _followService.GetAllAsync();
            return Ok(response);
        }

        // GET: api/follows/detailed/by-follower/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("detailed/by-follower/{followerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDetailedByFollowerIdAsync([FromRoute] string followerId)
        {
            var response = await _followService.GetAllDetailedByFollowerIdAsync(followerId);
            return Ok(response);
        }

        // GET: api/follows/detailed/by-following/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("detailed/by-following/{followingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDetailedByFollowingIdAsync([FromRoute] string followingId)
        {
            var response = await _followService.GetAllDetailedByFollowingIdAsync(followingId);
            return Ok(response);
        }

        // GET: api/follows/detailed/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("detailed/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedByIdAsync([FromRoute] string id)
        {
            var response = await _followService.GetDetailedByIdAsync(id);
            return this.HandleResponse(response);
        }

        // GET: api/follows/detailed
        [HttpGet("detailed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDetailedAsync()
        {
            var response = await _followService.GetAllDetailedAsync();
            return Ok(response);
        }

        // GET: api/follows/by-follower/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-follower/{followerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByFollowerIdAsync([FromRoute] string followerId)
        {
            var response = await _followService.GetAllByFollowerIdAsync(followerId);
            return Ok(response);
        }

        // GET: api/follows/by-following/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-following/{followingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByFollowingIdAsync([FromRoute] string followingId)
        {
            var response = await _followService.GetAllByFollowingIdAsync(followingId);
            return Ok(response);
        }

        // GET: api/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _followService.GetByIdAsync(id);
            return this.HandleResponse(response);
        }

        // POST: api/follows
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] FollowAddDTO followAddDTO)
        {
            var response = await _followService.AddAsync(followAddDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/follows/by-following-and-follower/5f0f2dd0-e957-4d72-8141-767a36fc6e95/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("by-following-and-follower/{followingId}/{followerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByFollowerIdAndFollowingIdAsync([FromRoute] string followingId, [FromRoute] string followerId)
        {
            var response = await _followService.DeleteByFollowerIdAndFollowingIdAsync(followingId, followerId);

            return this.HandleResponse(response);
        }

        // DELETE: api/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var response = await _followService.DeleteAsync(id);

            return this.HandleResponse(response);
        }
    }
}
