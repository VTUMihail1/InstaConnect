using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetPostLikeById;
using InstaConnect.Posts.Web.Models.Requests.PostLike;
using InstaConnect.Posts.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Controllers;

[ApiController]
[Route("api/post-likes")]
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
    public async Task<IActionResult> GetAllAsync(CollectionRequestModel collectionRequestModel)
    {
        var getAllPostLikesQuery = _mapper.Map<GetAllPostLikesQuery>(collectionRequestModel);
        var response = await _sender.Send(getAllPostLikesQuery);
        var postLikeViewModels = _mapper.Map<ICollection<PostLikeViewModel>>(response);

        return Ok(postLikeViewModels);
    }

    // GET: api/post-likes/filtered
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetPostLikesCollectionRequestModel getPostLikesCollectionRequestModel)
    {
        var getAllFilteredPostLikesQuery = _mapper.Map<GetAllFilteredPostLikesQuery>(getPostLikesCollectionRequestModel);
        var response = await _sender.Send(getAllFilteredPostLikesQuery);
        var postLikeViewModels = _mapper.Map<ICollection<PostLikeViewModel>>(response);

        return Ok(postLikeViewModels);
    }

    // GET: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetPostLikeByIdRequestModel getPostLikeByIdRequestModel)
    {
        var getPostLikeByIdQuery = _mapper.Map<GetPostLikeByIdQuery>(getPostLikeByIdRequestModel);
        var response = await _sender.Send(getPostLikeByIdQuery);
        var postLikeViewModel = _mapper.Map<PostLikeViewModel>(response);

        return Ok(postLikeViewModel);
    }

    // POST: api/post-likes
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddPostLikeRequestModel addPostLikeRequestModel)
    {
        var addPostLikeCommand = _mapper.Map<AddPostLikeCommand>(addPostLikeRequestModel);
        await _sender.Send(addPostLikeCommand);

        return NoContent();
    }

    //DELETE: api/post-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeletePostLikeRequestModel deletePostLikeRequestModel)
    {
        var deletePostLikeCommand = _mapper.Map<DeletePostLikeCommand>(deletePostLikeRequestModel);
        await _sender.Send(deletePostLikeCommand);

        return NoContent();
    }
}
