using AutoMapper;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;
using InstaConnect.Users.Business.Queries.User.GetAllUsers;
using InstaConnect.Users.Business.Queries.User.GetDetailedUserById;
using InstaConnect.Users.Business.Queries.User.GetUser;
using InstaConnect.Users.Business.Queries.User.GetUserById;
using InstaConnect.Users.Business.Queries.User.GetUserByName;
using InstaConnect.Users.Business.Queries.User.GetUserDetailed;
using InstaConnect.Users.Web.Models.Requests.User;
using InstaConnect.Users.Web.Models.Response.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Users.Web.Controllers;

[ApiController]
[Route("api/users")]
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
        CollectionRequestModel request,
        CancellationToken cancellationToken)
    {
        var getAllUsersQuery = _mapper.Map<GetAllUsersQuery>(request);
        var userViewDTOs = await _sender.Send(getAllUsersQuery, cancellationToken);

        var userResponseModels = _mapper.Map<ICollection<UserResponseModel>>(userViewDTOs);

        return Ok(userResponseModels);
    }

    // GET: api/users/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        GetUserCollectionRequestModel request,
        CancellationToken cancellationToken)
    {
        var getAllFilteredUsersQuery = _mapper.Map<GetAllFilteredUsersQuery>(request);
        var userViewDTOs = await _sender.Send(getAllFilteredUsersQuery, cancellationToken);

        var userResponseModels = _mapper.Map<ICollection<UserResponseModel>>(userViewDTOs);

        return Ok(userResponseModels);
    }

    // GET: api/users/current/detailed
    [Authorize]
    [HttpGet("current/detailed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDetailedAsync(
        GetUserDetailedRequestModel request,
        CancellationToken cancellationToken)
    {
        var getUserDetailedQuery = _mapper.Map<GetUserDetailedQuery>(request);
        var userDetailedViewDTO = await _sender.Send(getUserDetailedQuery, cancellationToken);

        var userDetailedResponseModel = _mapper.Map<UserDetailedResponseModel>(userDetailedViewDTO);

        return Ok(userDetailedResponseModel);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/detailed
    [Authorize]
    [HttpGet("{id}/detailed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDetailedByIdAsync(
        GetUserDetailedByIdRequestModel request,
        CancellationToken cancellationToken)
    {
        var getUserDetailedByIdQuery = _mapper.Map<GetUserDetailedByIdQuery>(request);
        var userDetailedViewDTO = await _sender.Send(getUserDetailedByIdQuery, cancellationToken);

        var userDetailedResponseModel = _mapper.Map<UserDetailedResponseModel>(userDetailedViewDTO);

        return Ok(userDetailedResponseModel);
    }

    // GET: api/users/current
    [HttpGet("current")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(
        GetUserRequestModel request,
        CancellationToken cancellationToken)
    {
        var getUserQuery = _mapper.Map<GetUserQuery>(request);
        var userViewDTO = await _sender.Send(getUserQuery, cancellationToken);

        var userResponseModel = _mapper.Map<UserResponseModel>(userViewDTO);

        return Ok(userResponseModel);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(
        GetUserByIdRequestModel request,
        CancellationToken cancellationToken)
    {
        var getUserByIdQuery = _mapper.Map<GetUserByIdQuery>(request);
        var userViewDTO = await _sender.Send(getUserByIdQuery, cancellationToken);

        var userResponseModel = _mapper.Map<UserResponseModel>(userViewDTO);

        return Ok(userResponseModel);
    }

    // GET: api/users/by-username/example
    [HttpGet("by-username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByUsernameAsync(
        GetUserByNameRequestModel request,
        CancellationToken cancellationToken)
    {
        var getUserByNameQuery = _mapper.Map<GetUserByNameQuery>(request);
        var userViewDTO = await _sender.Send(getUserByNameQuery, cancellationToken);

        var userResponseModel = _mapper.Map<UserResponseModel>(userViewDTO);

        return Ok(userResponseModel);
    }
}
