using AutoMapper;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetPostById;
using InstaConnect.Posts.Web.Models.Requests.Post;
using InstaConnect.Posts.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Controllers;

[ApiController]
[Route("api/posts")]
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
    public async Task<IActionResult> GetAllAsync(CollectionRequest request)
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
    public async Task<IActionResult> GetAllFilteredAsync(GetPostsCollectionRequest request)
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

    // POST: api/posts
    [HttpPost]
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
