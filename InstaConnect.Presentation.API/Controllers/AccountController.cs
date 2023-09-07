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

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // POST: api/Account/login
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] AccountLoginDTO request)
        {
            var response = await _accountService.LoginAsync(request);

            if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            return NoContent();
        }

        // DELETE: api/Account/log-out
        [HttpDelete("log-out")]
        [Authorize]
        public async Task<IActionResult> LogOutAsync()
        {
            // Not implemented yer, since I need a token service for that
            return Ok();
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

            var confirmEmailTokenResponse = await _accountService.GenerateConfirmEmailTokenAsync(signUpResponse.Data.Email);

            if (confirmEmailTokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(signUpResponse.ErrorMessages);
            }

            return Ok(confirmEmailTokenResponse.Data);
        }

        // GET: api/Account/confirm-email/afsfasff44afa/dtshstd434tfgre-dsf4w
        [HttpGet("confirm-email/{email}/{token}")]
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

            return Ok(response.Data);
        }

        // GET: api/Account/request-access-token
        [HttpGet("request-access-token")]
        [Authorize]
        public async Task<IActionResult> RequestAccessTokenAsync()
        {
            // This will be implemented when the token service is implemented
            return Ok();
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

            return Ok(response.Data);
        }

        // POST: api/Account/reset-password/user@example.com/asdasfasgsagfasfasd
        [HttpPost("reset-password/{email}/{token}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromRoute] string email, [FromRoute] string token, [FromBody] AccountResetPasswordDTO request)
        {
            var response = await _accountService.ResetPasswordAsync(email, token, request);

            if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            return NoContent();
        }
    }
}
