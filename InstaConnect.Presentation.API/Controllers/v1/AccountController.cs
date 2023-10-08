using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Data.Models.Utilities;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/accounts")]
    [ApiVersion("1.0")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/v1/accounts/confirm-email/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpGet("confirm-email/by-user/{userId}/by-token/{encodedToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmailAsync([FromRoute] string userId, [FromRoute] string encodedToken)
        {
            var response = await _accountService.ConfirmEmailWithTokenAsync(userId, encodedToken);

            return this.HandleResponse(response);
        }

        // GET: api/v1/accounts/resend-confirm-email-token/by-email/user@example.com
        [HttpGet("resend-confirm-email-token/by-email/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResendConfirmEmailTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.ResendEmailConfirmationTokenAsync(email);

            return this.HandleResponse(response);
        }

        // GET: api/v1/accounts/send-reset-password-token/by-email/user@example.com
        [HttpGet("send-reset-password-token/by-email/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendResetPasswordTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.SendPasswordResetTokenByEmailAsync(email);

            return this.HandleResponse(response);
        }

        // POST: api/v1/accounts/login
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] AccountLoginDTO request)
        {
            var response = await _accountService.LoginAsync(request);

            return this.HandleResponse(response);
        }

        // POST: api/v1/accounts/sign-up
        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUpAsync([FromBody] AccountRegistrationDTO request)
        {
            var response = await _accountService.SignUpAsync(request);

            return this.HandleResponse(response);
        }

        // DELETE: api/v1/accounts/logout
        [HttpDelete("logout")]
        [Authorize]
        [AccessToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogoutAsync()
        {
            var accessToken = HttpContext.Request.Headers.Authorization;
            var response = await _accountService.LogoutAsync(accessToken);

            return this.HandleResponse(response);
        }

        // POST: api/v1/accounts/reset-password/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpPost("reset-password/by-user/{userId}/by-token/{encodedToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromRoute] string userId, [FromRoute] string encodedToken, [FromBody] AccountResetPasswordDTO request)
        {
            var response = await _accountService.ResetPasswordWithTokenAsync(userId, encodedToken, request);

            return this.HandleResponse(response);
        }

        // PUT: api/v1/accounts/current
        [Authorize]
        [AccessToken]
        [HttpPut("current")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditByCurrentIdAsync([FromBody] AccountEditDTO accountEditDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _accountService.EditAsync(currentUserId, accountEditDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/v1/accounts/current
        [Authorize]
        [AccessToken]
        [HttpDelete("current")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentIdAsync()
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _accountService.DeleteAsync(currentUserId);

            return this.HandleResponse(response);
        }

        // DELETE: api/v1/accounts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [RequiredRole(InstaConnectConstants.AdminRole)]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] string userId)
        {
            var response = await _accountService.DeleteAsync(userId);

            return this.HandleResponse(response);
        }
    }
}
