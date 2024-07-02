using Asp.Versioning;
using AutoMapper;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetPostCommentById;
using InstaConnect.Posts.Web.Read.Models.Requests.Post;
using InstaConnect.Posts.Web.Read.Models.Requests.PostComment;
using InstaConnect.Posts.Web.Read.Models.Responses;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Posts.Web.Read.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/post-comments")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class PostCommentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public PostCommentController(
        IMapper mapper,
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/post-comments
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync(GetAllPostsRequest request)
    {
        var queryRequest = _mapper.Map<GetAllPostCommentsQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<PostCommentResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comments/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetAllFilteredPostCommentsRequest request)
    {
        var queryRequest = _mapper.Map<GetAllFilteredPostCommentsQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<PostCommentResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/post-comments/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetPostCommentByIdRequest request)
    {
        var queryRequest = _mapper.Map<GetPostCommentByIdQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<PostCommentResponse>(queryResponse);

        return Ok(response);
    }
}

