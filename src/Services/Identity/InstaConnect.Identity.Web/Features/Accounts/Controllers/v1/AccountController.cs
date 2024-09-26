using Asp.Versioning;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ConfirmAccountEmail;
using InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteAccountById;
using InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;
using InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;
using InstaConnect.Identity.Web.Features.Accounts.Models.Requests;
using InstaConnect.Identity.Web.Features.Accounts.Models.Responses;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Identity.Web.Features.Accounts.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/accounts")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class AccountController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly ICurrentUserContext _currentUserContext;

    public AccountController(
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectSender instaConnectSender,
        ICurrentUserContext currentUserContext)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
        _currentUserContext = currentUserContext;
    }

    // GET: api/accounts/confirm-email/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
    [HttpGet("confirm-email/by-user/{userId}/by-token/{token}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ConfirmEmailAsync(
        ConfirmAccountEmailRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<ConfirmAccountEmailCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // GET: api/accounts/resend-confirm-email/by-email/user@example.com
    [HttpGet("resend-confirm-email/by-email/{email}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ResendConfirmEmailAsync(
        ResendAccountConfirmEmailRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<ResendAccountEmailConfirmationCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // GET: api/accounts/send-reset-password/by-email/user@example.com
    [HttpGet("send-reset-password/by-email/{email}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SendResetPasswordAsync(
        SendAccountPasswordResetRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<SendAccountPasswordResetCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // POST: api/accounts/login
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AccountTokenCommandResponse>> LoginAsync(
        LoginAccountRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<LoginAccountCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        var response = _instaConnectMapper.Map<AccountTokenCommandResponse>(commandResponse);

        return Ok(response);
    }

    // POST: api/accounts/register
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AccountCommandResponse>> RegisterAsync(
        RegisterAccountRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<RegisterAccountCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<AccountCommandResponse>(commandResponse);

        return Ok(response);
    }

    // POST: api/accounts/reset-password/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
    [HttpPost("reset-password/by-user/{userId}/by-token/{token}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ResetPasswordAsync(
        ResetAccountPasswordRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<ResetAccountPasswordCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // PUT: api/accounts/current
    [Authorize]
    [HttpPut("current")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AccountCommandResponse>> EditCurrentAsync(
        EditCurrentAccountRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<EditCurrentAccountCommand>((currentUser, request));
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<AccountCommandResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/accounts/current
    [Authorize]
    [HttpDelete("current")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCurrentAsync(
        CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<DeleteCurrentAccountCommand>(currentUser);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // DELETE: api/accounts/admin/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [Authorize(AppPolicies.AdminPolicy)]
    [HttpDelete("admin/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteByIdAsync(
        DeleteAccountByIdRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<DeleteAccountByIdCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
