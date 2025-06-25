using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.Login;
using InstaConnect.Identity.Application.Features.Users.Commands.Update;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetByName;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrent;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailedById;

namespace InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;

[ApiVersion(UserRoutes.Version1)]
[Route(UserRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class UserController : ControllerBase
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public UserController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // GET: api/users
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserPaginationQueryResponse>> GetAllAsync(
        GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllUsersQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<UserPaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current/detailed
    [HttpGet(UserRoutes.CurrentDetailed)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetailedQueryResponse>> GetCurrentDetailedAsync(
        GetCurrentDetailedUserRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetCurrentDetailedUserQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<UserDetailedQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/detailed
    [HttpGet(UserRoutes.IdDetailed)]
    [Authorize(AppPolicies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetailedQueryResponse>> GetDetailedByIdAsync(
        GetDetailedUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetDetailedUserByIdQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<UserDetailedQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current
    [HttpGet(UserRoutes.Current)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserQueryResponse>> GetCurrentAsync(
        GetCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetCurrentUserQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<UserQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(UserRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserQueryResponse>> GetByIdAsync(
        GetUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetUserByIdQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<UserQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/by-name/example
    [HttpGet(UserRoutes.Name)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserQueryResponse>> GetByNameAsync(
        GetUserByNameRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetUserByNameQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<UserQueryResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/users/login
    [HttpPost(UserRoutes.Login)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserTokenCommandResponse>> LoginAsync(
        LoginUserRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<LoginUserCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);

        var response = _applicationMapper.Map<UserTokenCommandResponse>(commandResponse);

        return Ok(response);
    }

    // POST: api/users/register
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserCommandResponse>> AddAsync(
        AddUserRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddUserCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<UserCommandResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/users/current
    [Authorize]
    [HttpPut(UserRoutes.Current)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserCommandResponse>> UpdateCurrentAsync(
        UpdateCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<UpdateUserCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<UserCommandResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/users/current
    [Authorize]
    [HttpDelete(UserRoutes.Current)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCurrentAsync(
        DeleteCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteUserCommand>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // DELETE: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [Authorize(AppPolicies.AdminPolicy)]
    [HttpDelete(UserRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteUserCommand>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
