using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Enums;
using Microsoft.AspNetCore.Authorization;
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

            var accessToken = _tokenService.GenerateAccessToken(loginResponse.Data);
            var tokenResponse = _tokenService.AddAsync(accessToken.Data);

            return Ok(tokenResponse);
        }

        // DELETE: api/Account/log-out
        [HttpDelete("log-out")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogOutAsync([FromHeader] HttpContext httpContext)
        {
            var accessToken = httpContext.Response.Headers.Authorization;

            var response = await _tokenService.RemoveAsync(accessToken);

            if(response.StatusCode == InstaConnectStatusCode.Unauthorized)
            {
                return Unauthorized(response.ErrorMessages);
            }

            return NoContent();
        }

        // POST: api/Account/sign-up
        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUpAsync([FromBody] AccountRegistrationDTO request)
        {
            var signUpResponse = await _accountService.SignUpAsync(request);

            if (signUpResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(signUpResponse.ErrorMessages);
            }

            var confirmEmailTokenResponse = await _accountService.GenerateConfirmEmailTokenAsync(signUpResponse.Data.Id);

            if (confirmEmailTokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(signUpResponse.ErrorMessages);
            }

            var tokenValue = _tokenService.GenerateEmailConfirmationToken(confirmEmailTokenResponse.Data);
            var tokenResponse = await _tokenService.AddAsync(tokenValue.Data);

            return Ok(tokenResponse);
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

            return NoContent();
        }

        // GET: api/Account/generate-confirm-email-token/user@example.com
        [HttpGet("generate-confirm-email-token/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateConfirmEmailTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.GenerateConfirmEmailTokenAsync(email);

            if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            var tokenValue = _tokenService.GenerateEmailConfirmationToken(response.Data);
            var tokenResponse = await _tokenService.AddAsync(tokenValue.Data);

            return Ok(tokenResponse.Data);
        }

        // GET: api/Account/generate-reset-password-token/user@example.com
        [HttpGet("generate-reset-password-token/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateResetPasswordTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.GenerateResetPasswordTokenAsync(email);

            if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            var tokenValue = _tokenService.GeneratePasswordResetToken(response.Data);
            var tokenResponse = await _tokenService.AddAsync(tokenValue.Data);

            return Ok(tokenResponse);
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

            return NoContent();
        }
    }
}
