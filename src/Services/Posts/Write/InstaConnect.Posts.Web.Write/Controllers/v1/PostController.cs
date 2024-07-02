using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Web.Models.Requests.Post;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/posts")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ICurrentUserContext _currentUserContext;

    public PostController(
        IMapper mapper,
        ISender sender,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _sender = sender;
        _currentUserContext = currentUserContext;
    }

    // POST: api/posts
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<AddPostCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }

    // PUT: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(UpdatePostRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<UpdatePostCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }

    //DELETE: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeletePostRequest request)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<DeletePostCommand>(request);
        _mapper.Map(currentUser, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }
}
