using AutoMapper;
using InstaConnect.Shared.Web.Utils;
using InstaConnect.Users.Business.Commands.Account.ConfirmAccountEmail;
using InstaConnect.Users.Business.Commands.Account.DeleteAccount;
using InstaConnect.Users.Business.Commands.Account.DeleteAccountById;
using InstaConnect.Users.Business.Commands.Account.EditAccount;
using InstaConnect.Users.Business.Commands.Account.LoginAccount;
using InstaConnect.Users.Business.Commands.Account.RegisterAccount;
using InstaConnect.Users.Business.Commands.Account.ResendAccountEmailConfirmation;
using InstaConnect.Users.Business.Commands.Account.ResetAccountPassword;
using InstaConnect.Users.Web.Extensions;
using InstaConnect.Users.Web.Models.Requests.Account;
using InstaConnect.Users.Web.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Users.Web.Controllers;

[ApiController]
[Route("api/accounts")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
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
        [FromBody] LoginAccountRequest request,
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
        [FromBody] RegisterAccountRequest request,
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

    // PUT: api/accounts
    [Authorize]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditAsync(
        [FromBody] EditAccountRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<EditAccountCommand>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // DELETE: api/accounts
    [Authorize]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(
        DeleteAccountRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<DeleteAccountCommand>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }

    // DELETE: api/accounts/admin/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [Authorize(AppPolicies.AdminPolicy)]
    [HttpDelete("admin/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteByIdAsync(
        [FromRoute] DeleteAccountByIdRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _mapper.Map<DeleteAccountByIdCommand>(request);
        await _sender.Send(commandRequest, cancellationToken);

        return NoContent();
    }
}
