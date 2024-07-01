using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Web.Models.Requests.Post;
using InstaConnect.Posts.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
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

    public PostController(
        IMapper mapper,
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // POST: api/posts
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostRequest request)
    {
        var commandRequest = _mapper.Map<AddPostCommand>(request);
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
        var commandRequest = _mapper.Map<UpdatePostCommand>(request);
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
        var commandRequest = _mapper.Map<DeletePostCommand>(request);
        await _sender.Send(commandRequest);

        return NoContent();
    }
}
