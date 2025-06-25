using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

namespace InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;

[ApiController]
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

    // GET: api/follows
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FollowPaginationQueryResponse>> GetAllAsync(
        GetAllFollowsRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllFollowsQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<FollowPaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(FollowRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FollowQueryResponse>> GetByIdAsync(
        GetFollowByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetFollowByIdQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<FollowQueryResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/follows
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FollowCommandResponse>> AddAsync(
        AddFollowRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddFollowCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<FollowCommandResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(FollowRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeleteFollowRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteFollowCommand>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
