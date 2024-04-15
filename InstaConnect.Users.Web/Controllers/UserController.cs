using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Models.Utilities;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Users.Web.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/v1/users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] string firstName = default,
            [FromQuery] string lastName = default,
            [FromQuery][Range(InstaConnectModelConfigurations.PageMinLength, int.MaxValue)] int page = 1,
            [FromQuery][Range(InstaConnectModelConfigurations.AmountMinLength, int.MaxValue)] int amount = 18)
        {
            var response = await _userService.GetAllAsync(firstName, lastName, page, amount);

            return this.HandleResponse(response);
        }

        // GET: api/v1/users/personal-details/current
        [Authorize]
        [AccessToken]
        [HttpGet("personal-details/current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonalByCurrentIdAsync()
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _userService.GetPersonalByIdAsync(currentUserId);

            return this.HandleResponse(response);
        }

        // GET: api/v1/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/personal-details
        [Authorize]
        [AccessToken]
        [RequiredRole(InstaConnectConstants.AdminRole)]
        [HttpGet("{id}/personal-details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonalByIdAsync([FromRoute] string id)
        {
            var response = await _userService.GetPersonalByIdAsync(id);

            return this.HandleResponse(response);
        }

        // GET: api/v1/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var response = await _userService.GetByIdAsync(id);

            return this.HandleResponse(response);
        }

        // GET: api/v1/users/by-username/example
        [HttpGet("by-username/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUsernameAsync([FromRoute] string username)
        {
            var response = await _userService.GetByUsernameAsync(username);

            return this.HandleResponse(response);
        }
    }
}
