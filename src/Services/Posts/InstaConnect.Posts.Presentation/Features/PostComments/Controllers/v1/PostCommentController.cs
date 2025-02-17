using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;

[ApiVersion(PostCommentRoutes.Version1)]
[Route(PostCommentRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostCommentController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;

    public PostCommentController(
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectSender instaConnectSender)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
    }

    // GET: api/post-comments
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostCommentPaginationQueryResponse>> GetAllAsync(
        GetAllPostCommentsRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllPostCommentsQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentPaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(PostCommentRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostCommentQueryResponse>> GetByIdAsync(
        GetPostCommentByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetPostCommentByIdQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentQueryResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/post-comments
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostCommentCommandResponse>> AddAsync(
        AddPostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<AddPostCommentCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentCommandResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut(PostCommentRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostCommentCommandResponse>> UpdateAsync(
        UpdatePostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<UpdatePostCommentCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentCommandResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(PostCommentRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeletePostCommentRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<DeletePostCommentCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}

