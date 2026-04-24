using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

[ApiVersion(PostLikeRoutes.Version1)]
[Route(PostLikeRoutes.UserResource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class UserPostLikeController : ControllerBase
{
    private readonly IApplicationMapper _mapper;
    private readonly IApplicationSender _sender;

    public UserPostLikeController(
        IApplicationMapper mapper,
        IApplicationSender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/post-likes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllPostLikesForUserApiResponse>> GetAllAsync(
        GetAllPostLikesForUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _mapper.Map<GetAllPostLikesForUserQueryRequest>(request);
        var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
        var response = _mapper.Map<GetAllPostLikesForUserApiResponse>(queryResponse);

        return Ok(response);
    }
}
