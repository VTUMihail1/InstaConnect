using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

[ApiVersion(PostLikeRoutes.Version1)]
[Route(PostLikeRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostLikeController : ControllerBase
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public PostLikeController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostLikePaginationQueryResponse>> GetAllAsync(
        GetAllPostLikesRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllPostLikesQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<PostLikePaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(PostLikeRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostLikeQueryResponse>> GetByIdAsync(
        GetPostLikeByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetPostLikeByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<PostLikeQueryResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostLikeCommandResponse>> AddAsync(
        AddPostLikeRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddPostLikeCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<PostLikeCommandResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(PostLikeRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(
        DeletePostLikeRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeletePostLikeCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
