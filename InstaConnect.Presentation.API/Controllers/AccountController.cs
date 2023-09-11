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

            var addTokenResponse = await _tokenService.AddAccessTokenAsync(loginResponse.Data);

            return Ok(addTokenResponse.Data);
        }

        // DELETE: api/Account/logout
        [HttpDelete("logout")]
        [Token]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogOutAsync()
        {
            var accessToken = HttpContext.Request.Headers.Authorization;

            var removeTokenResponse = await _tokenService.RemoveAsync(accessToken);

            if (removeTokenResponse.StatusCode == InstaConnectStatusCode.Unauthorized)
            {
                return Unauthorized(removeTokenResponse.ErrorMessages);
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

        // GET: api/Account/confirm-email/5f0f2dd0-e957-4d72-8141-767a36fc6e95/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5ZmtLTUViRS92WnZhYTVCWnU2dEovZ1Y0SUx2TmdaNTF0aEc4TUhiQXR6UHVDTTVEQWxKbWNXNXdjbzluUXgxNGNNTVpNNG1uaEh0d3B0ZDc4UGx5VzllWmVxR1RnODk2MU56Rjg1dzYwUU11VlVhYXR6cHA0VE1xVGFvS3c2UWlQU2E3YXU3Z0g5ZE1PV1FlMUhYY2VSdDI2QWpQem90bHViRC95azN5dG5kRER5UUtSa3RjcktES2RwZ3Z2aXRuR3ErcFF1cHZrUUxUUUM1Q3pmK2ZJaFV2MVArdTkwdz09
        [HttpGet("confirm-email/{userId}/{token}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmailAsync([FromRoute] string userId, [FromRoute] string token)
        {
            var confirmEmailResponse = await _accountService.ConfirmEmailAsync(userId, token);

            if (confirmEmailResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(confirmEmailResponse.ErrorMessages);
            }

            var removeTokenResponse = await _tokenService.RemoveAsync(confirmEmailResponse.Data);

            if (removeTokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(removeTokenResponse.ErrorMessages);
            }

            return NoContent();
        }

        // GET: api/Account/send-confirm-email-token/user@example.com
        [HttpGet("send-confirm-email-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendConfirmEmailTokenAsync([FromRoute] string email)
        {
            var sendEmailVerificationTokenResponse = await _accountService.SendAccountConfirmEmailTokenAsync(email);

            if (sendEmailVerificationTokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(sendEmailVerificationTokenResponse.ErrorMessages);
            }

            await _tokenService.AddEmailConfirmationTokenAsync(sendEmailVerificationTokenResponse.Data);

            return NoContent();
        }

        // GET: api/Account/generate-reset-password-token/user@example.com
        [HttpGet("send-reset-password-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendResetPasswordTokenAsync([FromRoute] string email)
        {
            var sendForgotPasswordTokenResponse = await _accountService.SendAccountResetPasswordTokenAsync(email);

            if (sendForgotPasswordTokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(sendForgotPasswordTokenResponse.ErrorMessages);
            }

            await _tokenService.AddPasswordResetTokenAsync(sendForgotPasswordTokenResponse.Data);

            return NoContent();
        }

        // POST: api/Account/reset-password/5f0f2dd0-e957-4d72-8141-767a36fc6e95/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5ZmtLTUViRS92WnZhYTVCWnU2dEovZ1Y0SUx2TmdaNTF0aEc4TUhiQXR6UHVDTTVEQWxKbWNXNXdjbzluUXgxNGNNTVpNNG1uaEh0d3B0ZDc4UGx5VzllWmVxR1RnODk2MU56Rjg1dzYwUU11VlVhYXR6cHA0VE1xVGFvS3c2UWlQU2E3YXU3Z0g5ZE1PV1FlMUhYY2VSdDI2QWpQem90bHViRC95azN5dG5kRER5UUtSa3RjcktES2RwZ3Z2aXRuR3ErcFF1cHZrUUxUUUM1Q3pmK2ZJaFV2MVArdTkwdz09
        [HttpPost("reset-password/{userId}/{token}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromRoute] string userId, [FromRoute] string token, [FromBody] AccountResetPasswordDTO request)
        {
            var resetPasswordResponse = await _accountService.ResetPasswordAsync(userId, token, request);

            if (resetPasswordResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(resetPasswordResponse.ErrorMessages);
            }

            var removeTokenResponse = await _tokenService.RemoveAsync(resetPasswordResponse.Data);

            if (removeTokenResponse.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return BadRequest(removeTokenResponse.ErrorMessages);
            }

            return NoContent();
        }
    }
}
