using Asp.Versioning;
using AutoMapper;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Read.Web.Models.Requests.Messages;
using InstaConnect.Messages.Read.Web.Models.Responses;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Messages.Read.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/messages")]
[Authorize]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class MessageController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly ICurrentUserContext _currentUserContext;

    public MessageController(
        IInstaConnectMapper instaConnectMapper, 
        IInstaConnectSender instaConnectSender, 
        ICurrentUserContext currentUserContext)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
        _currentUserContext = currentUserContext;
    }

    // GET: api/messages/filtered
    [HttpGet("filtered")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFilteredAsync(GetAllFilteredMessagesRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var queryRequest = _instaConnectMapper.Map<GetAllFilteredMessagesQuery>(request);
        _instaConnectMapper.Map(currentUser, queryRequest);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<ICollection<MessageViewResponse>>(queryResponse);

        return Ok(response);
    }

    // GET: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(GetMessageByIdRequest request, CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetMessageByIdQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageViewResponse>(queryResponse);

        return Ok(response);
    }
}

