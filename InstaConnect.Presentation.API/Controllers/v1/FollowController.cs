using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Presentation.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/follows")]
    [ApiVersion("1.0")]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        // GET: api/v1/follows
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string followerId = default,
            [FromQuery] string followingId = default,
            [FromQuery][Range(InstaConnectModelConfigurations.PageMinLength, int.MaxValue)] int page = 1,
            [FromQuery][Range(InstaConnectModelConfigurations.AmountMinLength, int.MaxValue)] int amount = 18)
        {
            var response = await _followService.GetAllAsync(followerId, followingId, page, amount);

            return this.HandleResponse(response);
        }

        // GET: api/v1/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _followService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        //GET: api/v1/follows/by-follower/current/by-following/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("by-follower/current/by-following/{followingId:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByFollowerIdAndFollowingIdAsync([FromRoute] string followerId, [FromRoute] string followingId)
        {
            var response = await _followService.GetByFollowerIdAndFollowingIdAsync(followingId, followerId);

            return this.HandleResponse(response);
        }

        // POST: api/v1/follows
        [Authorize]
        [AccessToken]
        [ValidateUser("FollowerId")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AddAsync([FromBody] FollowAddDTO followAddDTO)
        {
            var response = await _followService.AddAsync(followAddDTO);

            return this.HandleResponse(response);
        }

        //DELETE: api/v1/follows/by-follower/current/by-following/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [HttpDelete("by-follower/current/by-following/{followingId:alpha}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentFollowerIdAndFollowingIdAsync([FromRoute] string followingId)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _followService.DeleteByFollowerIdAndFollowingIdAsync(currentUserId, followingId);

            return this.HandleResponse(response);
        }

        //DELETE: api/v1/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-follower/current
        [Authorize]
        [AccessToken]
        [HttpDelete("{id:alpha}/by-follower/current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCurrentFollowerAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _followService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }
    }
}
