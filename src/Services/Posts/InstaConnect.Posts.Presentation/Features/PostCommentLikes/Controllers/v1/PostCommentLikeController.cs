using Asp.Versioning;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Posts.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

[ApiVersion(PostCommentLikeRoutes.Version1)]
[Route(PostCommentLikeRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostCommentLikeController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;

    public PostCommentLikeController(
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectSender instaConnectSender)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
    }

    // GET: api/post-comment-likes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostCommentLikePaginationQueryResponse>> GetAllAsync(
        GetAllPostCommentLikesRequest request, 
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllPostCommentLikesQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentLikePaginationQueryResponse>(queryResponse);

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
        var queryRequest = _instaConnectMapper.Map<GetPostCommentLikeByIdQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentLikeQueryResponse>(queryResponse);

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
        var commandRequest = _instaConnectMapper.Map<AddPostCommentLikeCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentLikeCommandResponse>(commandResponse);

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
        var commandRequest = _instaConnectMapper.Map<DeletePostCommentLikeCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
