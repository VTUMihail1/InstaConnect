using Asp.Versioning;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Presentation.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

[ApiVersion(PostLikeRoutes.Version1)]
[Route(PostLikeRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostLikeController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;

    public PostLikeController(
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectSender instaConnectSender)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
    }

    // GET: api/post-likes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostLikePaginationQueryResponse>> GetAllAsync(
        GetAllPostLikesRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllPostLikesQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostLikePaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(PostLikeRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostLikeQueryResponse>> GetByIdAsync(
        GetPostLikeByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetPostLikeByIdQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostLikeQueryResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/post-likes
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostLikeCommandResponse>> AddAsync(
        AddPostLikeRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<AddPostLikeCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostLikeCommandResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(PostLikeRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(
        DeletePostLikeRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<DeletePostLikeCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
