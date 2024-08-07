using Asp.Versioning;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllFilteredUsers;
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
    public async Task<IActionResult> GetAllAsync(
        GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllUsersQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<ICollection<UserQueryResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current/detailed
    [HttpGet("current/detailed")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrentDetailedAsync(CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var queryRequest = _instaConnectMapper.Map<GetCurrentUserDetailedQuery>(currentUser);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserDetailedQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/detailed
    [HttpGet("{id}/detailed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDetailedByIdAsync(
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
    public async Task<IActionResult> GetCurrentAsync(CancellationToken cancellationToken)
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
    public async Task<IActionResult> GetByIdAsync(
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
    public async Task<IActionResult> GetByUsernameAsync(
        GetUserByNameRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetUserByNameQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);

        var response = _instaConnectMapper.Map<UserQueryResponse>(queryResponse);

        return Ok(response);
    }
}
