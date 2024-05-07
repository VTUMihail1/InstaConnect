using AutoMapper;
using InstaConnect.Shared.Data.Utilities;
using InstaConnect.Users.Business.Commands.Account.ConfirmAccountEmail;
using InstaConnect.Users.Business.Commands.Account.DeleteAccount;
using InstaConnect.Users.Business.Commands.Account.EditAccount;
using InstaConnect.Users.Business.Commands.Account.LoginAccount;
using InstaConnect.Users.Business.Commands.Account.LogoutAccount;
using InstaConnect.Users.Business.Commands.Account.RegisterAccount;
using InstaConnect.Users.Business.Commands.Account.ResendAccountEmailConfirmation;
using InstaConnect.Users.Business.Commands.Account.ResetAccountPassword;
using InstaConnect.Users.Web.Extensions;
using InstaConnect.Users.Web.Filters;
using InstaConnect.Users.Web.Models.Requests.Account;
using InstaConnect.Users.Web.Models.Response.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Controllers;

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
        [FromRoute] ConfirmAccountEmailTokenRequestModel request,
        CancellationToken cancellationToken)
    {
        var confirmAccountEmailCommand = _mapper.Map<ConfirmAccountEmailCommand>(request);

        await _sender.Send(confirmAccountEmailCommand, cancellationToken);

        return NoContent();
    }

    // GET: api/accounts/resend-confirm-email/by-email/user@example.com
    [HttpGet("resend-confirm-email/by-email/{email}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResendConfirmEmailAsync(
        [FromRoute] ResendAccountConfirmEmailRequestModel request,
        CancellationToken cancellationToken)
    {
        var resendAccountEmailConfirmationCommand = _mapper.Map<ResendAccountEmailConfirmationCommand>(request);

        await _sender.Send(resendAccountEmailConfirmationCommand, cancellationToken);

        return NoContent();
    }

    // GET: api/accounts/send-reset-password/by-email/user@example.com
    [HttpGet("send-reset-password/by-email/{email}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SendResetPasswordAsync(
        [FromRoute] SendAccountPasswordResetRequestModel request,
        CancellationToken cancellationToken)
    {
        var sendAccountPasswordResetRequestModel = _mapper.Map<SendAccountPasswordResetRequestModel>(request);

        await _sender.Send(sendAccountPasswordResetRequestModel, cancellationToken);

        return NoContent();
    }

    // POST: api/accounts/login
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginAccountRequestModel request,
        CancellationToken cancellationToken)
    {
        var loginAccountCommand = _mapper.Map<LoginAccountCommand>(request);

        var accountViewDTO = await _sender.Send(loginAccountCommand, cancellationToken);

        var response = _mapper.Map<AccountResponseModel>(accountViewDTO);

        return Ok(response);
    }

    // POST: api/accounts/register
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterAccountRequestModel request,
        CancellationToken cancellationToken)
    {
        var registerAccountCommand = _mapper.Map<RegisterAccountCommand>(request);

        await _sender.Send(registerAccountCommand, cancellationToken);

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
        var logoutaccountCommand = _mapper.Map<LogoutAccountCommand>(request);

        await _sender.Send(logoutaccountCommand, cancellationToken);

        return NoContent();
    }

    // POST: api/accounts/reset-password/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
    [HttpPost("reset-password/by-user/{userId}/by-token/{token}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPasswordAsync(
        ResetAccountPasswordRequestModel request,
        CancellationToken cancellationToken)
    {
        var resetAccountPasswordCommand = _mapper.Map<ResetAccountPasswordCommand>(request);

        await _sender.Send(resetAccountPasswordCommand, cancellationToken);

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
        [FromBody] EditAccountRequestModel request,
        CancellationToken cancellationToken)
    {
        var userRequestModel = User.GetUserRequestModel();
        var editAccountCommand = _mapper.Map<EditAccountCommand>(request);
        _mapper.Map(userRequestModel, editAccountCommand);

        await _sender.Send(editAccountCommand, cancellationToken);

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
        var deleteAccountCommand = _mapper.Map<DeleteAccountCommand>(userRequestModel);

        await _sender.Send(deleteAccountCommand, cancellationToken);

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
        [FromRoute] DeleteAccountRequestModel request,
        CancellationToken cancellationToken)
    {
        var deleteAccountCommand = _mapper.Map<DeleteAccountCommand>(request);

        await _sender.Send(deleteAccountCommand, cancellationToken);

        return NoContent();
    }
}
