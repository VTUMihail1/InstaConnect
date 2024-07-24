using System.Threading;
using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Read.Business.Queries.PostComments.GetPostCommentById;
using InstaConnect.Posts.Read.Web.Models.Requests.Post;
using InstaConnect.Posts.Read.Web.Models.Requests.PostComment;
using InstaConnect.Posts.Read.Web.Models.Responses;
using InstaConnect.Posts.Write.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Write.Business.Commands.PostComments.DeletePostComment;
using InstaConnect.Posts.Write.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Write.Web.Models.Requests.PostComment;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Write.Web.Controllers.v1;

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
    public async Task<IActionResult> GetAllAsync(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllPostCommentsQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<PostCommentQueryResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comments/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetAllFilteredPostCommentsRequest request, CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllFilteredPostCommentsQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<PostCommentQueryResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetPostCommentByIdRequest request, CancellationToken cancellationToken)
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
    public async Task<IActionResult> AddAsync(AddPostCommentRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<AddPostCommentCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
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
    public async Task<IActionResult> UpdateAsync(UpdatePostCommentRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<UpdatePostCommentCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
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
    public async Task<IActionResult> DeleteAsync(DeletePostCommentRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<DeletePostCommentCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}

