using Asp.Versioning;
using AutoMapper;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetAllFollows;
using InstaConnect.Follows.Business.Read.Queries.Follows.GetFollowById;
using InstaConnect.Follows.Web.Read.Models.Requests.Follows;
using InstaConnect.Follows.Web.Read.Models.Responses;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Follows.Web.Read.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/follows")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
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
    public async Task<IActionResult> GetAllAsync(GetAllFollowsRequest request)
    {
        var queryRequest = _mapper.Map<GetAllFollowsQuery>(request);
        var response = await _sender.Send(queryRequest);
        var followViewModels = _mapper.Map<ICollection<FollowResponse>>(response);

        return Ok(followViewModels);
    }

    // GET: api/follows/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetAllFilteredFollowsRequest request)
    {
        var queryRequest = _mapper.Map<GetAllFilteredFollowsQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<FollowResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetFollowByIdRequest request)
    {
        var queryRequest = _mapper.Map<GetFollowByIdQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<FollowResponse>(queryResponse);

        return Ok(response);
    }
}
