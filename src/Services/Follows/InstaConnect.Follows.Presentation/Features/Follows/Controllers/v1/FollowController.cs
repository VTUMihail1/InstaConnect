using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Commands.Delete;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

namespace InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;

[ApiVersion(FollowRoutes.Version1)]
[Route(FollowRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class FollowController : ControllerBase
{
    private readonly IApplicationMapper _mapper;
    private readonly IApplicationSender _sender;

    public FollowController(
        IApplicationMapper mapper,
        IApplicationSender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/followers/current/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(FollowRoutes.CurrentId)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetFollowByIdApiResponse>> GetByIdAsync(
        GetFollowByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _mapper.Map<GetFollowByIdQueryRequest>(request);
        var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
        var response = _mapper.Map<GetFollowByIdApiResponse>(queryResponse);

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
        var commandRequest = _mapper.Map<AddFollowCommandRequest>(request);
        var commandResponse = await _sender.SendAsync(commandRequest, cancellationToken);
        var response = _mapper.Map<AddFollowApiResponse>(commandResponse);

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
        var commandRequest = _mapper.Map<DeleteFollowCommandRequest>(request);
        await _sender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
