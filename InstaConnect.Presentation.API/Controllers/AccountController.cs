using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Presentation.API.Extensions;
using InstaConnect.Presentation.API.Filters;
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
        public async Task<IActionResult> LoginAsync([FromBody] AccountLoginDTO loginDTO)
        {
            var loginResponse = await _accountService.LoginAsync(loginDTO);

            if (loginResponse.StatusCode != InstaConnectStatusCode.OK)
            {
                return this.HandleResponse(loginResponse);
            }

            var addTokenResponse = await _tokenService.AddAccessTokenAsync(loginResponse.Data);

            return this.HandleResponse(addTokenResponse);
        }

        // DELETE: api/Account/logout
        [HttpDelete("logout")]
        [Authorize]
        [AccessToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogoutAsync()
        {
            var accessToken = HttpContext.Request.Headers.Authorization;

            var removeTokenResponse = await _tokenService.RemoveAsync(accessToken);

            return this.HandleResponse(removeTokenResponse);
        }

        // POST: api/Account/sign-up
        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUpAsync([FromBody] AccountRegistrationDTO registrationDTO)
        {
            var signUpResponse = await _accountService.SignUpAsync(registrationDTO);

            if (signUpResponse.StatusCode != InstaConnectStatusCode.OK)
            {
                return this.HandleResponse(signUpResponse);
            }

            var confirmEmailTokenResponse = await _accountService.SendEmailConfirmationTokenAsync(registrationDTO.Email);
            var addEmailConfirmationTokenResponse = await _tokenService.AddEmailConfirmationTokenAsync(confirmEmailTokenResponse.Data);

            return this.HandleResponse(addEmailConfirmationTokenResponse);
        }

        // GET: api/Account/confirm-email/5f0f2dd0-e957-4d72-8141-767a36fc6e95/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpGet("confirm-email/{userId}/{encodedToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmailAsync([FromRoute] string userId, [FromRoute] string encodedToken)
        {
            var confirmEmailResponse = await _accountService.ConfirmEmailWithTokenAsync(userId, encodedToken);

            if (confirmEmailResponse.StatusCode != InstaConnectStatusCode.OK)
            {
                return this.HandleResponse(confirmEmailResponse);
            }

            var removeTokenResponse = await _tokenService.RemoveAsync(confirmEmailResponse.Data);

            return this.HandleResponse(removeTokenResponse);
        }

        // GET: api/Account/send-confirm-email-token/user@example.com
        [HttpGet("send-confirm-email-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendConfirmEmailTokenAsync([FromRoute] string email)
        {
            var sendEmailVerificationTokenResponse = await _accountService.SendEmailConfirmationTokenAsync(email);

            if (sendEmailVerificationTokenResponse.StatusCode != InstaConnectStatusCode.OK)
            {
                return this.HandleResponse(sendEmailVerificationTokenResponse);
            }

            var addEmailConfirmationTokenResponse = await _tokenService.AddEmailConfirmationTokenAsync(sendEmailVerificationTokenResponse.Data);

            return this.HandleResponse(addEmailConfirmationTokenResponse);
        }

        // GET: api/Account/send-reset-password-token/user@example.com
        [HttpGet("send-reset-password-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendResetPasswordTokenAsync([FromRoute] string email)
        {
            var sendForgotPasswordTokenResponse = await _accountService.SendPasswordResetTokenByEmailAsync(email);

            if (sendForgotPasswordTokenResponse.StatusCode != InstaConnectStatusCode.OK)
            {
                return this.HandleResponse(sendForgotPasswordTokenResponse);
            }

            var addPasswordResetTokenResponse = await _tokenService.AddPasswordResetTokenAsync(sendForgotPasswordTokenResponse.Data);

            return this.HandleResponse(addPasswordResetTokenResponse);
        }

        // POST: api/Account/reset-password/5f0f2dd0-e957-4d72-8141-767a36fc6e95/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpPost("reset-password/{userId}/{encodedToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromRoute] string userId, [FromRoute] string encodedToken, [FromBody] AccountResetPasswordDTO resetPasswordDTO)
        {
            var resetPasswordResponse = await _accountService.ResetPasswordWithTokenAsync(userId, encodedToken, resetPasswordDTO);

            if (resetPasswordResponse.StatusCode != InstaConnectStatusCode.OK)
            {
                return this.HandleResponse(resetPasswordResponse);
            }

            var removeTokenResponse = await _tokenService.RemoveAsync(resetPasswordResponse.Data);

            return this.HandleResponse(removeTokenResponse);
        }
    }
}
