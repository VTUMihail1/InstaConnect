using Asp.Versioning;
using AutoMapper;
using InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;
using InstaConnect.Identity.Business.Commands.Account.DeleteAccount;
using InstaConnect.Identity.Business.Commands.Account.DeleteAccountById;
using InstaConnect.Identity.Business.Commands.Account.EditAccount;
using InstaConnect.Identity.Business.Commands.Account.LoginAccount;
using InstaConnect.Identity.Business.Commands.Account.RegisterAccount;
using InstaConnect.Identity.Business.Commands.Account.ResendAccountEmailConfirmation;
using InstaConnect.Identity.Business.Commands.Account.ResetAccountPassword;
using InstaConnect.Identity.Web.Models.Requests.Account;
using InstaConnect.Identity.Web.Models.Response;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Identity.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/accounts")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class AccountController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ICurrentUserContext _currentUserContext;

    public AccountController(
        IMapper mapper,
        ISender sender,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _sender = sender;
        _currentUserContext = currentUserContext;
    }

    // GET: api/accounts/confirm-email/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
    [HttpGet("confirm-email/by-user/{userId}/by-token/{token}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConfirmEmailAsync(
        ConfirmAccountEmailTokenRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<ConfirmAccountEmailCommand>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // GET: api/accounts/resend-confirm-email/by-email/user@example.com
    [HttpGet("resend-confirm-email/by-email/{email}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResendConfirmEmailAsync(
        ResendAccountConfirmEmailRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<ResendAccountEmailConfirmationCommand>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // GET: api/accounts/send-reset-password/by-email/user@example.com
    [HttpGet("send-reset-password/by-email/{email}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SendResetPasswordAsync(
        SendAccountPasswordResetRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<SendAccountPasswordResetRequest>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // POST: api/accounts/login
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LoginAsync(
        LoginAccountRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<LoginAccountCommand>(request);
        var commandResponse = await _sender.Send(commandRequest, cancellationToken);

        var response = _mapper.Map<AccountResponse>(commandResponse);

        return Ok(response);
    }

    // POST: api/accounts/register
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(
        RegisterAccountRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<RegisterAccountCommand>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // POST: api/accounts/reset-password/by-user/5f0f2dd0-e957-4d72-8141-767a36fc6e95/by-token/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
    [HttpPost("reset-password/by-user/{userId}/by-token/{token}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPasswordAsync(
        ResetAccountPasswordRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<ResetAccountPasswordCommand>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // PUT: api/accounts/current
    [Authorize]
    [HttpPut("current")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditAsync(
        EditCurrentAccountRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<EditCurrentAccountCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // DELETE: api/accounts/current
    [Authorize]
    [HttpDelete("current")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCurrentAsync(
        CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<DeleteCurrentAccountCommand>(currentUser);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // DELETE: api/accounts/admin/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [Authorize(AppPolicies.AdminPolicy)]
    [HttpDelete("admin/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteByIdAsync(
        DeleteAccountByIdRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<DeleteAccountByIdCommand>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }
}
