using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Controllers.v1;

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

    // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllPostCommentLikesApiResponse>> GetAllAsync(
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllPostCommentLikesQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetAllPostCommentLikesApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(PostCommentLikeRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetPostCommentLikeByIdApiResponse>> GetByIdAsync(
        GetPostCommentLikeByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetPostCommentLikeByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetPostCommentLikeByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddPostCommentLikeApiResponse>> AddAsync(
        AddPostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddPostCommentLikeCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<AddPostCommentLikeApiResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95/likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(PostCommentLikeRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeletePostCommentLikeApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeletePostCommentLikeCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
