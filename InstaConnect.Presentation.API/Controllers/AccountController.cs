﻿using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
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

            return this.HandleResponse(response);
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
            var response = await _accountService.LogoutAsync(accessToken);

            return this.HandleResponse(response);
        }

        // POST: api/Account/sign-up
        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUpAsync([FromBody] AccountRegistrationDTO request)
        {
            var response = await _accountService.SignUpAsync(request);

            return this.HandleResponse(response);
        }

        // GET: api/Account/confirm-email/5f0f2dd0-e957-4d72-8141-767a36fc6e95/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpGet("confirm-email/{userId}/{encodedToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmailAsync([FromRoute] string userId, [FromRoute] string encodedToken)
        {
            var response = await _accountService.ConfirmEmailWithTokenAsync(userId, encodedToken);

            return this.HandleResponse(response);
        }

        // GET: api/Account/resend-confirm-email-token/user@example.com
        [HttpGet("resend-confirm-email-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResendConfirmEmailTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.ResendEmailConfirmationTokenAsync(email);

            return this.HandleResponse(response);
        }

        // GET: api/Account/send-reset-password-token/user@example.com
        [HttpGet("send-reset-password-token/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendResetPasswordTokenAsync([FromRoute] string email)
        {
            var response = await _accountService.SendPasswordResetTokenByEmailAsync(email);

            return this.HandleResponse(response);
        }

        // POST: api/Account/reset-password/5f0f2dd0-e957-4d72-8141-767a36fc6e95/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpPost("reset-password/{userId}/{encodedToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromRoute] string userId, [FromRoute] string encodedToken, [FromBody] AccountResetPasswordDTO request)
        {
            var response = await _accountService.ResetPasswordWithTokenAsync(userId, encodedToken, request);

            return this.HandleResponse(response);
        }
    }
}
