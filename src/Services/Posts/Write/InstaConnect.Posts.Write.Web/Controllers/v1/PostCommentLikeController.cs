using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Write.Web.Models.Requests.PostCommentLike;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Write.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/post-comment-likes")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostCommentLikeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ICurrentUserContext _currentUserContext;

    public PostCommentLikeController(
        IMapper mapper,
        ISender sender,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _sender = sender;
        _currentUserContext = currentUserContext;
    }

    // POST: api/post-comment-likes
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostCommentLikeRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<AddPostCommentLikeCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }

    //DELETE: api/posts-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeletePostCommentLikeRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<DeletePostCommentLikeCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }
}
