using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/accounts/confirm-email/5f0f2dd0-e957-4d72-8141-767a36fc6e95/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpGet("confirm-email/{userId}/{encodedToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmailAsync([FromRoute] string userId, [FromRoute] string encodedToken)
        {
            var response = await _accountService.ConfirmEmailWithTokenAsync(userId, encodedToken);

            return this.HandleResponse(response);
        }

        // GET: api/accounts/resend-confirm-email-token/user@example.com
        [HttpGet("resend-confirm-email-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResendConfirmEmailTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.ResendEmailConfirmationTokenAsync(email);

            return this.HandleResponse(response);
        }

        // GET: api/accounts/send-reset-password-token/user@example.com
        [HttpGet("send-reset-password-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendResetPasswordTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.SendPasswordResetTokenByEmailAsync(email);

            return this.HandleResponse(response);
        }

        // POST: api/accounts/login
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] AccountLoginDTO request)
        {
            var response = await _accountService.LoginAsync(request);

            return this.HandleResponse(response);
        }

        // POST: api/accounts/sign-up
        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUpAsync([FromBody] AccountRegistrationDTO request)
        {
            var response = await _accountService.SignUpAsync(request);

            return this.HandleResponse(response);
        }

        // DELETE: api/accounts/logout
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

        // POST: api/accounts/reset-password/5f0f2dd0-e957-4d72-8141-767a36fc6e95/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpPost("reset-password/{userId}/{encodedToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromRoute] string userId, [FromRoute] string encodedToken, [FromBody] AccountResetPasswordDTO request)
        {
            var response = await _accountService.ResetPasswordWithTokenAsync(userId, encodedToken, request);

            return this.HandleResponse(response);
        }

        // PUT: api/accounts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpPut("{id}")]
        [Authorize]
        [AccessToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditAsync([FromRoute] string id, [FromBody] AccountEditDTO accountEditDTO)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _accountService.EditAsync(currentUserId, id, accountEditDTO);

            return this.HandleResponse(response);
        }

        // DELETE: api/accounts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [HttpDelete("{id}")]
        [Authorize]
        [AccessToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var currentUserId = User.GetCurrentUserId();
            var response = await _accountService.DeleteAsync(currentUserId, id);

            return this.HandleResponse(response);
        }
    }
}
