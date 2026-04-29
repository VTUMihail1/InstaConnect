using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;

[ApiVersion(PostCommentRoutes.Version1)]
[Route(PostCommentRoutes.UserResource)]
[EnableRateLimiting(RateLimiterPolicies.Default)]
public class UserPostCommentController : ControllerBase
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserPostCommentController(
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
	public async Task<ActionResult<GetAllPostCommentsForUserApiResponse>> GetAllAsync(
		GetAllPostCommentsForUserApiRequest request,
		CancellationToken cancellationToken)
	{
		var queryRequest = _mapper.Map<GetAllPostCommentsForUserQueryRequest>(request);
		var queryResponse = await _sender.SendAsync(queryRequest, cancellationToken);
		var response = _mapper.Map<GetAllPostCommentsForUserApiResponse>(queryResponse);

		return Ok(response);
	}
}
