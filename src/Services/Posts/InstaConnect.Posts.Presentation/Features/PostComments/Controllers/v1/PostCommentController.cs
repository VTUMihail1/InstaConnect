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

    // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllPostCommentsApiResponse>> GetAllAsync(
        GetAllPostCommentsApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllPostCommentsQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetAllPostCommentsApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(PostCommentRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetPostCommentByIdApiResponse>> GetByIdAsync(
        GetPostCommentByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetPostCommentByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetPostCommentByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddPostCommentApiResponse>> AddAsync(
        AddPostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddPostCommentCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<AddPostCommentApiResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut(PostCommentRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UpdatePostCommentApiResponse>> UpdateAsync(
        UpdatePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<UpdatePostCommentCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<UpdatePostCommentApiResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(PostCommentRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeletePostCommentApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeletePostCommentCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
