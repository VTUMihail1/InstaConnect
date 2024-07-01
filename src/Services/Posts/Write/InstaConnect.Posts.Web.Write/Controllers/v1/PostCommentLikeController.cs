using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Web.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/post-comment-likes")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostCommentLikeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public PostCommentLikeController(
        IMapper mapper,
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // POST: api/post-comment-likes
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostCommentLikeRequest request)
    {
        var commandRequest = _mapper.Map<AddPostCommentLikeCommand>(request);
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
        var commandRequest = _mapper.Map<DeletePostCommentLikeCommand>(request);
        await _sender.Send(commandRequest);

        return NoContent();
    }
}
