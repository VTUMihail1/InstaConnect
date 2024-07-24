using System.Threading;
using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Read.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Read.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Read.Business.Queries.Posts.GetPostById;
using InstaConnect.Posts.Read.Web.Models.Requests.Post;
using InstaConnect.Posts.Read.Web.Models.Responses;
using InstaConnect.Posts.Write.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Write.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Write.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Write.Web.Models.Requests.Post;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Write.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/posts")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly ICurrentUserContext _currentUserContext;

    public PostController(
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectSender instaConnectSender,
        ICurrentUserContext currentUserContext)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
        _currentUserContext = currentUserContext;
    }

    // GET: api/posts
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllPostsQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<PostQueryResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/posts/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetAllFilteredPostsRequest request, CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllFilteredPostsQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<PostQueryResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetPostByIdRequest request, CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetPostByIdQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostQueryResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/posts
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<AddPostCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommandResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(UpdatePostRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<UpdatePostCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommandResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeletePostRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<DeletePostCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
