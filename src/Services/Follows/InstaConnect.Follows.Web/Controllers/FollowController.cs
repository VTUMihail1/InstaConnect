using AutoMapper;
using InstaConnect.Follows.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Business.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Business.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Business.Queries.Follows.GetFollowById;
using InstaConnect.Follows.Web.Models.Requests.Follows;
using InstaConnect.Follows.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Controllers;

[ApiController]
[Route("api/follows")]
public class FollowController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public FollowController(
        IMapper mapper,
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/follows
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync(CollectionRequestModel collectionRequestModel)
    {
        var getAllFollowsQuery = _mapper.Map<GetAllFollowsQuery>(collectionRequestModel);
        var response = await _sender.Send(getAllFollowsQuery);
        var followViewModels = _mapper.Map<ICollection<FollowViewModel>>(response);

        return Ok(followViewModels);
    }

    // GET: api/follows/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetFollowCollectionRequestModel getFollowCollectionRequestModel)
    {
        var getAllFilteredFollowsQuery = _mapper.Map<GetAllFilteredFollowsQuery>(getFollowCollectionRequestModel);
        var response = await _sender.Send(getAllFilteredFollowsQuery);
        var followViewModels = _mapper.Map<ICollection<FollowViewModel>>(response);

        return Ok(followViewModels);
    }

    // GET: api/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetFollowByIdRequestModel getFollowByIdRequestModel)
    {
        var getFollowByIdQuery = _mapper.Map<GetFollowByIdQuery>(getFollowByIdRequestModel);
        var response = await _sender.Send(getFollowByIdQuery);
        var followLikeViewModel = _mapper.Map<FollowViewModel>(response);

        return Ok(followLikeViewModel);
    }

    // POST: api/follows
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddFollowRequestModel addFollowRequestModel)
    {
        var addFollowCommand = _mapper.Map<AddFollowCommand>(addFollowRequestModel);
        await _sender.Send(addFollowCommand);

        return NoContent();
    }

    //DELETE: api/posts-comment-likes/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeleteFollowRequestModel deleteFollowRequestModel)
    {
        var deleteFollowCommand = _mapper.Map<DeleteFollowCommand>(deleteFollowRequestModel);
        await _sender.Send(deleteFollowCommand);

        return NoContent();
    }
}
