using Asp.Versioning;
using InstaConnect.Identity.Business.Features.Users.Commands.ConfirmUserEmail;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteUserById;
using InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Business.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Business.Features.Users.Commands.ResendUserEmailConfirmation;
using InstaConnect.Identity.Business.Features.Users.Commands.ResetUserPassword;
using InstaConnect.Identity.Business.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Web.Features.Users.Models.Requests;
using InstaConnect.Identity.Web.Features.Users.Models.Responses;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Identity.Web.Features.Users.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class UserController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly ICurrentUserContext _currentUserContext;

    public UserController(
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectSender instaConnectSender,
        ICurrentUserContext currentUserContext)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
        _currentUserContext = currentUserContext;
    }

    // GET: api/users
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserPaginationQueryResponse>> GetAllAsync(
        GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllUsersQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserPaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current/detailed
    [HttpGet("current/detailed")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetailedQueryResponse>> GetCurrentDetailedAsync(CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var queryRequest = _instaConnectMapper.Map<GetCurrentUserDetailedQuery>(currentUser);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserDetailedQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/detailed
    [HttpGet("{id}/detailed")]
    [Authorize(AppPolicies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetailedQueryResponse>> GetDetailedByIdAsync(
        GetUserDetailedByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetUserDetailedByIdQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserDetailedQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current
    [HttpGet("current")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserQueryResponse>> GetCurrentAsync(CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var queryRequest = _instaConnectMapper.Map<GetCurrentUserQuery>(currentUser);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserQueryResponse>> GetByIdAsync(
        GetUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetUserByIdQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/by-username/example
    [HttpGet("by-username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserQueryResponse>> GetByNameAsync(
        GetUserByNameRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetUserByNameQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/confirm-email/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
    [HttpGet("{userId}/confirm-email/{token}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ConfirmEmailAsync(
        ConfirmUserEmailRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<ConfirmUserEmailCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // GET: api/users/by-email/user@example.com/confirm-email
    [HttpGet("by-email/{email}/confirm-email")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ResendConfirmEmailAsync(
        ResendUserConfirmEmailRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<ResendUserEmailConfirmationCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // GET: api/users/by-email/user@example.com/reset-password
    [HttpGet("/by-email/{email}/reset-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SendResetPasswordAsync(
        SendUserPasswordResetRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<SendUserPasswordResetCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // POST: api/users/login
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserTokenCommandResponse>> LoginAsync(
        LoginUserRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<LoginUserCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserTokenCommandResponse>(commandResponse);

        return Ok(response);
    }

    // POST: api/users/register
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserCommandResponse>> RegisterAsync(
        RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<RegisterUserCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<UserCommandResponse>(commandResponse);

        return Ok(response);
    }

    // POST: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/reset-password/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg
    [HttpPost("{userId}/reset-password/{token}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ResetPasswordAsync(
        ResetUserPasswordRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<ResetUserPasswordCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // PUT: api/users/current
    [Authorize]
    [HttpPut("current")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserCommandResponse>> EditCurrentAsync(
        EditCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<EditCurrentUserCommand>((currentUser, request));
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<UserCommandResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/users/current
    [Authorize]
    [HttpDelete("current")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCurrentAsync(
        CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<DeleteCurrentUserCommand>(currentUser);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // DELETE: api/users/admin/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [Authorize(AppPolicies.AdminPolicy)]
    [HttpDelete("{id}/admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteByIdAsync(
        DeleteUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<DeleteUserByIdCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
