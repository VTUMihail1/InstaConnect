using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Presentation.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        // POST: api/Account/login
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] AccountLoginDTO request)
        {
            var loginResponse = await _accountService.LoginAsync(request);

            if (loginResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(loginResponse.ErrorMessages);
            }

            var tokenResponse = await _tokenService.AddAccessTokenAsync(loginResponse.Data);

            return Ok(tokenResponse.Data);
        }

        // DELETE: api/Account/log-out
        [HttpDelete("log-out")]
        [Token]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogOutAsync()
        {
            var accessToken = HttpContext.Request.Headers.Authorization;

            var tokenResponse = await _tokenService.RemoveAsync(accessToken);

            if (tokenResponse.StatusCode == InstaConnectStatusCode.Unauthorized)
            {
                return Unauthorized(tokenResponse.ErrorMessages);
            }

            return NoContent();
        }

        // POST: api/Account/sign-up
        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUpAsync([FromBody] AccountRegistrationDTO request)
        {
            var signUpResponse = await _accountService.SignUpAsync(request);

            if (signUpResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(signUpResponse.ErrorMessages);
            }

            var confirmEmailTokenResponse = await _accountService.SendAccountConfirmEmailTokenAsync(request.Email);

            if (confirmEmailTokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(confirmEmailTokenResponse.ErrorMessages);
            }

            await _tokenService.AddEmailConfirmationTokenAsync(confirmEmailTokenResponse.Data);

            return NoContent();
        }

        // GET: api/Account/confirm-email/afsfasff44afa/dtshstd434tfgre-dsf4w
        [HttpGet("confirm-email/{userId}/{token}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmailAsync([FromRoute] string userId, [FromRoute] string token)
        {
            var response = await _accountService.ConfirmEmailAsync(userId, token);

            if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            var tokenResponse = await _tokenService.RemoveAsync(response.Data);

            if (tokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(tokenResponse.ErrorMessages);
            }

            return NoContent();
        }

        // GET: api/Account/send-confirm-email-token/user@example.com
        [HttpGet("send-confirm-email-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendConfirmEmailTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.SendAccountConfirmEmailTokenAsync(email);

            if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            await _tokenService.AddEmailConfirmationTokenAsync(response.Data);

            return NoContent();
        }

        // GET: api/Account/generate-reset-password-token/user@example.com
        [HttpGet("send-reset-password-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendResetPasswordTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.SendAccountResetPasswordTokenAsync(email);

            if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            await _tokenService.AddPasswordResetTokenAsync(response.Data);

            return NoContent();
        }

        // POST: api/Account/reset-password/usadfsdafase/asdasfasgsagfasfasd
        [HttpPost("reset-password/{userId}/{token}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromRoute] string userId, [FromRoute] string token, [FromBody] AccountResetPasswordDTO request)
        {
            var response = await _accountService.ResetPasswordAsync(userId, token, request);

            if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            var tokenResponse = await _tokenService.RemoveAsync(response.Data);

            if (tokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(tokenResponse.ErrorMessages);
            }

            return NoContent();
        }
    }
}
