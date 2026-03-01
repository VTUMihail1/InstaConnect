using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollower;

namespace InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;

[ApiVersion(FollowRoutes.Version1)]
[Route(FollowRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class FollowForFollowerController : ControllerBase
{
    private readonly IApplicationMapper _mapper;
    private readonly IApplicationSender _sender;

    public FollowForFollowerController(
        IApplicationMapper mapper,
        IApplicationSender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/followers/5f0f2dd0-e957-4d72-8141-767a36fc6e95/follows
    [HttpGet(FollowRoutes.FollowerResource)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllFollowsForFollowerApiResponse>> GetAllAsync(
        GetAllFollowsForFollowerApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _mapper.Map<GetAllFollowsForFollowerQueryRequest>(request);
        var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
        var response = _mapper.Map<GetAllFollowsForFollowerApiResponse>(queryResponse);

        return Ok(response);
    }
}
