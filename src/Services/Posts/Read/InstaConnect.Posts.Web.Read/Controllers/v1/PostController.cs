using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetPostById;
using InstaConnect.Posts.Web.Read.Models.Requests.Post;
using InstaConnect.Posts.Web.Read.Models.Requests.PostComment;
using InstaConnect.Posts.Web.Read.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Web.Read.Controllers.v1;

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

    // GET: api/posts
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync(GetAllPostsQuery request)
    {
        var queryRequest = _mapper.Map<GetAllPostsQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<PostResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/posts/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetAllFilteredPostsRequest request)
    {
        var queryRequest = _mapper.Map<GetAllFilteredPostsQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<PostResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/posts/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetPostByIdRequest request)
    {
        var queryRequest = _mapper.Map<GetPostByIdQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<PostResponse>(queryResponse);

        return Ok(response);
    }
}
