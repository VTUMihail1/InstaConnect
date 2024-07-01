using Asp.Versioning;
using AutoMapper;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetAllMessages;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Web.Read.Models.Requests.Messages;
using InstaConnect.Messages.Web.Read.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Messages.Web.Read.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/messages")]
[Authorize]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class MessageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public MessageController(
        IMapper mapper,
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // GET: api/messages
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync(CollectionRequest request)
    {
        var queryRequest = _mapper.Map<GetAllMessagesQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<MessageViewResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/messages/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetMessageCollectionRequest request)
    {
        var queryRequest = _mapper.Map<GetAllFilteredMessagesQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<ICollection<MessageViewResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetMessageByIdRequest request)
    {
        var queryRequest = _mapper.Map<GetMessageByIdQuery>(request);
        var queryResponse = await _sender.Send(queryRequest);
        var response = _mapper.Map<MessageViewResponse>(queryResponse);

        return Ok(response);
    }
}

