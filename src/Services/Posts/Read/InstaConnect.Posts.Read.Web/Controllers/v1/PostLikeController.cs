using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Read.Business.Queries.PostLikes.GetPostLikeById;
using InstaConnect.Posts.Read.Web.Models.Requests.PostLike;
using InstaConnect.Posts.Read.Web.Models.Responses;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Read.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/post-likes")]
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
    public async Task<IActionResult> GetAllAsync(GetAllPostLikesRequest request)
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
    public async Task<IActionResult> GetAllFilteredAsync(GetAllFilteredPostLikesRequest request)
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
}
