using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

[ApiVersion(PostCommentLikeRoutes.Version1)]
[Route(PostCommentLikeRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostCommentLikeController : ControllerBase
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public PostCommentLikeController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // GET: api/post-comment-likes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostCommentLikePaginationQueryResponse>> GetAllAsync(
        GetAllPostCommentLikesRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllPostCommentLikesQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<PostCommentLikePaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(PostCommentLikeRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostCommentQueryResponse>> GetByIdAsync(
        GetPostCommentLikeByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetPostCommentLikeByIdQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<PostCommentLikeQueryResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/post-comment-likes
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostCommentLikeCommandResponse>> AddAsync(
        AddPostCommentLikeRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddPostCommentLikeCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<PostCommentLikeCommandResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/posts-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(PostCommentLikeRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeletePostCommentLikeRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeletePostCommentLikeCommand>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
