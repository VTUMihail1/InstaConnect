using AutoMapper;
using InstaConnect.Shared.Data.Utilities;
using InstaConnect.Users.Business.Commands.AccountConfirmEmail;
using InstaConnect.Users.Business.Commands.AccountDelete;
using InstaConnect.Users.Business.Commands.AccountEdit;
using InstaConnect.Users.Business.Commands.AccountLogin;
using InstaConnect.Users.Business.Commands.AccountLogout;
using InstaConnect.Users.Business.Commands.AccountRegister;
using InstaConnect.Users.Business.Commands.AccountResendEmailConfirmation;
using InstaConnect.Users.Business.Commands.AccountResetPassword;
using InstaConnect.Users.Web.Extensions;
using InstaConnect.Users.Web.Filters;
using InstaConnect.Users.Web.Models.Requests.Account;
using InstaConnect.Users.Web.Models.Response.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public AccountController(
            IMapper mapper,
            ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        // GET: api/accounts/confirm-email/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpGet("confirm-email/by-user/{userId}/by-token/{token}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmailAsync(
            [FromRoute] AccountConfirmEmailTokenRequestModel request,
            CancellationToken cancellationToken)
        {
            var accountConfirmEmailCommand = _mapper.Map<AccountConfirmEmailCommand>(request);

            await _sender.Send(accountConfirmEmailCommand, cancellationToken);

            return NoContent();
        }

        // GET: api/accounts/resend-confirm-email/by-email/user@example.com
        [HttpGet("resend-confirm-email/by-email/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResendConfirmEmailAsync(
            [FromRoute] AccountResendConfirmEmailRequestModel request,
            CancellationToken cancellationToken)
        {
            var accountResendEmailConfirmationCommand = _mapper.Map<AccountResendEmailConfirmationCommand>(request);

            await _sender.Send(accountResendEmailConfirmationCommand, cancellationToken);

            return NoContent();
        }

        // GET: api/accounts/send-reset-password/by-email/user@example.com
        [HttpGet("send-reset-password/by-email/{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendResetPasswordAsync(
            [FromRoute] AccountSendPasswordResetRequestModel request,
            CancellationToken cancellationToken)
        {
            var accountResendEmailConfirmationCommand = _mapper.Map<AccountSendPasswordResetRequestModel>(request);

            await _sender.Send(accountResendEmailConfirmationCommand, cancellationToken);

            return NoContent();
        }

        // POST: api/accounts/login
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync(
            [FromBody] AccountLoginRequestModel request,
            CancellationToken cancellationToken)
        {
            var accountLoginCommand = _mapper.Map<AccountLoginCommand>(request);

            var accountViewDTO = await _sender.Send(accountLoginCommand, cancellationToken);

            var response = _mapper.Map<AccountResponseModel>(accountViewDTO);

            return Ok(response);
        }

        // POST: api/accounts/register
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] AccountRegisterRequestModel request,
            CancellationToken cancellationToken)
        {
            var accountRegisterCommand = _mapper.Map<AccountRegisterCommand>(request);

            await _sender.Send(accountRegisterCommand, cancellationToken);

            return NoContent();
        }

        // DELETE: api/accounts/logout
        [HttpDelete("logout")]
        [Authorize]
        [AccessToken]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogoutAsync(CancellationToken cancellationToken)
        {
            var request = HttpContext!.GetTokenRequestModel();
            var accountLogoutCommand = _mapper.Map<AccountLogoutCommand>(request);

            await _sender.Send(accountLogoutCommand, cancellationToken);

            return NoContent();
        }

        // POST: api/accounts/reset-password/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
        [HttpPost("reset-password/by-user/{userId}/by-token/{token}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync(
            AccountResetPasswordRequestModel request,
            CancellationToken cancellationToken)
        {
            var accountResetPasswordCommand = _mapper.Map<AccountResetPasswordCommand>(request);

            await _sender.Send(accountResetPasswordCommand, cancellationToken);

            return NoContent();
        }

        // PUT: api/accounts
        [Authorize]
        [AccessToken]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditAsync(
            [FromBody] AccountEditRequestModel request,
            CancellationToken cancellationToken)
        {
            var userRequestModel = User.GetUserRequestModel();
            var accountEditCommand = _mapper.Map<AccountEditCommand>(request);
            _mapper.Map(userRequestModel, accountEditCommand);

            await _sender.Send(accountEditCommand, cancellationToken);

            return NoContent();
        }

        // DELETE: api/accounts
        [Authorize]
        [AccessToken]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByCurrentIdAsync(CancellationToken cancellationToken)
        {
            var userRequestModel = User.GetUserRequestModel();
            var accountDeleteCommand = _mapper.Map<AccountDeleteCommand>(userRequestModel);

            await _sender.Send(accountDeleteCommand, cancellationToken);

            return NoContent();
        }

        // DELETE: api/accounts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
        [Authorize]
        [AccessToken]
        [RequiredRole(Roles.Admin)]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(
            [FromRoute] AccountDeleteRequestModel request,
            CancellationToken cancellationToken)
        {
            var accountDeleteCommand = _mapper.Map<AccountDeleteCommand>(request);

            await _sender.Send(accountDeleteCommand, cancellationToken);

            return NoContent();
        }
    }
}
