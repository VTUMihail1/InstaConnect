using Asp.Versioning;
using AutoMapper;
using InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Identity.Business.Queries.User.GetAllUsers;
using InstaConnect.Identity.Business.Queries.User.GetCurrentUser;
using InstaConnect.Identity.Business.Queries.User.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Queries.User.GetUserById;
using InstaConnect.Identity.Business.Queries.User.GetUserByName;
using InstaConnect.Identity.Business.Queries.User.GetUserDetailedById;
using InstaConnect.Identity.Web.Models.Requests.User;
using InstaConnect.Identity.Web.Models.Response;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Identity.Web.Controllers.v1;

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

    // GET: api/users/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllFilteredAsync(
        GetAllFilteredUsersRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllFilteredUsersQuery>(request);
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
