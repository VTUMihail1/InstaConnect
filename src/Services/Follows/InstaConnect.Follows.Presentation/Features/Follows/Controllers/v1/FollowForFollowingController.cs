using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;

namespace InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;

[ApiVersion(FollowRoutes.Version1)]
[Route(FollowRoutes.FollowingResource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class FollowForFollowingController : ControllerBase
{
    private readonly IApplicationMapper _mapper;
    private readonly IApplicationSender _sender;

    public FollowForFollowingController(
        IApplicationMapper mapper,
        IApplicationSender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/followings/5f0f2dd0-e957-4d72-8141-767a36fc6e95/follows
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllFollowsForFollowingApiResponse>> GetAllAsync(
        GetAllFollowsForFollowingApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _mapper.Map<GetAllFollowsForFollowingQueryRequest>(request);
        var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
        var response = _mapper.Map<GetAllFollowsForFollowingApiResponse>(queryResponse);

        return Ok(response);
    }
}
