using AutoMapper;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Shared.Web.Utils;
using InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.User.GetAllUsers;
using InstaConnect.Users.Business.Queries.User.GetUser;
using InstaConnect.Users.Business.Queries.User.GetUserById;
using InstaConnect.Users.Business.Queries.User.GetUserByName;
using InstaConnect.Users.Business.Queries.User.GetUserDetailed;
using InstaConnect.Users.Business.Queries.User.GetUserDetailedById;
using InstaConnect.Users.Web.Models.Requests.User;
using InstaConnect.Users.Web.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Users.Web.Controllers;

[ApiController]
[Route("api/users")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public UserController(
        IMapper mapper,
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/users
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        CollectionRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _mapper.Map<GetAllUsersQuery>(request);
        var queryResponse = await _sender.Send(queryRequest, cancellationToken);

        var response = _mapper.Map<ICollection<UserResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllFilteredAsync(
        GetUserCollectionRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _mapper.Map<GetAllFilteredUsersQuery>(request);
        var queryResponse = await _sender.Send(queryRequest, cancellationToken);

        var response = _mapper.Map<ICollection<UserResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current/detailed
    [HttpGet("current/detailed")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrentDetailedAsync(
        GetUserDetailedRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _mapper.Map<GetUserDetailedQuery>(request);
        var queryResponse = await _sender.Send(queryRequest, cancellationToken);

        var response = _mapper.Map<UserDetailedResponse>(queryResponse);

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
        var queryRequest = _mapper.Map<GetUserDetailedByIdQuery>(request);
        var queryResponse = await _sender.Send(queryRequest, cancellationToken);

        var response = _mapper.Map<UserDetailedResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current
    [HttpGet("current")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrentAsync(
        GetUserRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _mapper.Map<GetUserQuery>(request);
        var queryResponse = await _sender.Send(queryRequest, cancellationToken);

        var response = _mapper.Map<UserResponse>(queryResponse);

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
        var queryRequest = _mapper.Map<GetUserByIdQuery>(request);
        var queryResponse = await _sender.Send(queryRequest, cancellationToken);

        var response = _mapper.Map<UserResponse>(queryResponse);

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
        var queryRequest = _mapper.Map<GetUserByNameQuery>(request);
        var queryResponse = await _sender.Send(queryRequest, cancellationToken);

        var response = _mapper.Map<UserResponse>(queryResponse);

        return Ok(response);
    }
}
