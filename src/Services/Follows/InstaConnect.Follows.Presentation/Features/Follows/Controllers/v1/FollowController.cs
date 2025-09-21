using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;

[ApiVersion(FollowRoutes.Version1)]
[Route(FollowRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class FollowController : ControllerBase
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public FollowController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // GET: api/followers/5f0f2dd0-e957-4d72-8141-767a36fc6e95/follows
    [HttpGet(FollowRoutes.Follower)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllFollowsByFollowerApiResponse>> GetAllByFollowerAsync(
        GetAllFollowsByFollowerApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllFollowsByFollowerQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetAllFollowsByFollowerApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/followings/5f0f2dd0-e957-4d72-8141-767a36fc6e95/follows
    [HttpGet(FollowRoutes.Following)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllFollowsByFollowingApiResponse>> GetAllByFollowingAsync(
        GetAllFollowsByFollowingApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllFollowsByFollowingQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetAllFollowsByFollowingApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/followers/current/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(FollowRoutes.CurrentId)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetFollowByIdApiResponse>> GetByIdAsync(
        GetFollowByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetFollowByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetFollowByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/followers/current/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPost(FollowRoutes.CurrentId)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddFollowApiResponse>> AddAsync(
        AddFollowApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddFollowCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<AddFollowApiResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/followers/current/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(FollowRoutes.CurrentId)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeleteFollowApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteFollowCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
