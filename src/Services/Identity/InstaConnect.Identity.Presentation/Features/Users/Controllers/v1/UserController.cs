using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;
using InstaConnect.Users.Application.Features.Users.Commands.Update;
using InstaConnect.Users.Application.Features.Users.Queries.GetAll;
using InstaConnect.Users.Application.Features.Users.Queries.GetById;
using InstaConnect.Users.Presentation.Features.Users.Models.Requests;

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
    public async Task<ActionResult<GetAllUsersApiResponse>> GetAllAsync(
        GetAllUsersApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllUsersQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllUsersApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current/details
    [HttpGet(UserRoutes.CurrentDetails)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetCurrentUserByIdApiResponse>> GetCurrentDetailsByIdAsync(
        GetCurrentUserDetailsApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetCurrentUserByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<GetCurrentUserByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/details
    [HttpGet(UserRoutes.IdDetails)]
    [Authorize(AppPolicies.AdminPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetUserDetailsByIdApiResponse>> GetDetailsByIdAsync(
        GetUserDetailsByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetUserDetailsByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<GetUserDetailsByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/current
    [HttpGet(UserRoutes.Current)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetCurrentUserByIdApiResponse>> GetCurrentByIdAsync(
        GetCurrentUserByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetCurrentUserByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<GetCurrentUserByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(UserRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetUserByIdApiResponse>> GetByIdAsync(
        GetUserByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetUserByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);

        var response = _applicationMapper.Map<GetUserByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/users
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddUserApiResponse>> AddAsync(
        AddUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddUserCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<AddUserApiResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/users/current
    [Authorize]
    [HttpPut(UserRoutes.Current)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UpdateCurrentUserApiResponse>> UpdateCurrentAsync(
        UpdateCurrentUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<UpdateCurrentUserCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<UpdateCurrentUserApiResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/users/current
    [Authorize]
    [HttpDelete(UserRoutes.Current)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCurrentAsync(
        DeleteCurrentUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteCurrentUserCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // DELETE: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [Authorize(AppPolicies.AdminPolicy)]
    [HttpDelete(UserRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeleteUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteUserCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
