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
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public PostCommentController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // GET: api/post-comments
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostCommentPaginationQueryResponse>> GetAllAsync(
        GetAllPostCommentsRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllPostCommentsQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<PostCommentPaginationQueryResponse>(queryResponse);

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
        var queryRequest = _applicationMapper.Map<GetPostCommentByIdQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<PostCommentQueryResponse>(queryResponse);

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
        var commandRequest = _applicationMapper.Map<AddPostCommentCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<PostCommentCommandResponse>(commandResponse);

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
        var commandRequest = _applicationMapper.Map<UpdatePostCommentCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<PostCommentCommandResponse>(commandResponse);

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
        var commandRequest = _applicationMapper.Map<DeletePostCommentCommand>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}

