using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetPostCommentLikeById;
using InstaConnect.Posts.Web.Read.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Web.Read.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Shared.Web.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Web.Read.Controllers.v1;

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

    // GET: api/post-comment-likes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync(CollectionRequest request)
    {
        var queryRequest = _mapper.Map<GetAllPostCommentLikesQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<PostCommentLikeResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comment-likes/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetPostCommentLikesCollectionRequest request)
    {
        var queryRequest = _mapper.Map<GetAllFilteredPostCommentLikesQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<PostLikeResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetPostCommentLikeByIdRequest request)
    {
        var queryRequest = _mapper.Map<GetPostCommentLikeByIdQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<PostCommentLikeResponse>(queryResponse);

        return Ok(response);
    }
}
