using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Write.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Write.Business.Commands.PostComments.DeletePostComment;
using InstaConnect.Posts.Write.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Write.Web.Models.Requests.PostComment;
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
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ICurrentUserContext _currentUserContext;

    public PostCommentController(
        IMapper mapper,
        ISender sender,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _sender = sender;
        _currentUserContext = currentUserContext;
    }

    // POST: api/post-comments
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostCommentRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<AddPostCommentCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }

    // PUT: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(UpdatePostCommentRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<UpdatePostCommentCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }

    //DELETE: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeletePostCommentRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<DeletePostCommentCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }
}

