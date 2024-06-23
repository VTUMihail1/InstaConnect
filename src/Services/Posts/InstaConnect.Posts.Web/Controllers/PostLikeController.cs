using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetPostLikeById;
using InstaConnect.Posts.Web.Models.Requests.PostLike;
using InstaConnect.Posts.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Shared.Web.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Web.Controllers;

[ApiController]
[Route("api/post-likes")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostLikeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public PostLikeController(
        IMapper mapper,
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/post-likes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync(CollectionRequest request)
    {
        var queryRequest = _mapper.Map<GetAllPostLikesQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<PostLikeResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-likes/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetPostLikesCollectionRequest request)
    {
        var queryRequest = _mapper.Map<GetAllFilteredPostLikesQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<PostLikeResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetPostLikeByIdRequest request)
    {
        var queryRequest = _mapper.Map<GetPostLikeByIdQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<PostLikeResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/post-likes
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostLikeRequest request)
    {
        var addPostLikeCommand = _mapper.Map<AddPostLikeCommand>(request);
        await _sender.Send(addPostLikeCommand);

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
        var deletePostLikeCommand = _mapper.Map<DeletePostLikeCommand>(request);
        await _sender.Send(deletePostLikeCommand);

        return NoContent();
    }
}
