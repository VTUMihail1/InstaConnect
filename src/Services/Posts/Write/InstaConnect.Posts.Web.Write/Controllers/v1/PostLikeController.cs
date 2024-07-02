using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Business.Write.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Write.Commands.PostLikes.DeletePostLike;
using InstaConnect.Posts.Web.Write.Models.Requests.PostLike;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Web.Write.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/post-likes")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostLikeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ICurrentUserContext _currentUserContext;

    public PostLikeController(
        IMapper mapper,
        ISender sender,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _sender = sender;
        _currentUserContext = currentUserContext;
    }

    // POST: api/post-likes
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostLikeRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<AddPostLikeCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }

    //DELETE: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeletePostLikeRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<DeletePostLikeCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }
}
