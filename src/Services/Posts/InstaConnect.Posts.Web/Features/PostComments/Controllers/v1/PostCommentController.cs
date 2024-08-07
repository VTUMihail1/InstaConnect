using Asp.Versioning;
using InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.DeletePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Web.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Web.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Web.Features.Posts.Models.Requests;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Web.Features.PostComments.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/post-comments")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostCommentController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly ICurrentUserContext _currentUserContext;

    public PostCommentController(
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectSender instaConnectSender,
        ICurrentUserContext currentUserContext)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
        _currentUserContext = currentUserContext;
    }

    // GET: api/post-comments
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostCommentPaginationQueryResponse>> GetAllAsync(GetAllPostCommentsRequest request, CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllPostCommentsQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentPaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comments/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostCommentPaginationQueryResponse>> GetAllFilteredAsync(GetAllFilteredPostCommentsRequest request, CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllFilteredPostCommentsQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentPaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostCommentQueryResponse>> GetByIdAsync(GetPostCommentByIdRequest request, CancellationToken cancellationToken)
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
    public async Task<ActionResult<PostCommentCommandResponse>> AddAsync(AddPostCommentRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<AddPostCommentCommand>((currentUser, request));
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentCommandResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostCommentCommandResponse>> UpdateAsync(UpdatePostCommentRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<UpdatePostCommentCommand>((currentUser, request));
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentCommandResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(DeletePostCommentRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<DeletePostCommentCommand>((currentUser, request));
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}

