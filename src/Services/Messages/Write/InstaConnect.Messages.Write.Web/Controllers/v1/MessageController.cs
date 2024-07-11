using System.Security.Claims;
using Asp.Versioning;
using AutoMapper;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Web.Models.Requests.Messages;
using InstaConnect.Messages.Write.Web.Models.Responses;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Messages.Write.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/messages")]
[Authorize]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class MessageController : ControllerBase
{
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly ICurrentUserContext _currentUserContext;

    public MessageController(
        IInstaConnectSender instaConnectSender,
        IInstaConnectMapper instaConnectMapper,
        ICurrentUserContext currentUserContext)
    {
        _instaConnectSender = instaConnectSender;
        _instaConnectMapper = instaConnectMapper;
        _currentUserContext = currentUserContext;
    }

    // POST: api/messages
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageViewResponse>> AddAsync(AddMessageRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<AddMessageCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
        var commandResponse  = await _instaConnectSender.Send(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageViewResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageViewResponse>> UpdateAsync(UpdateMessageRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<UpdateMessageCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
        var commandResponse = await _instaConnectSender.Send(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageViewResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageViewResponse>> DeleteAsync(DeleteMessageRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<DeleteMessageCommand>(request);
        _instaConnectMapper.Map(currentUser, commandRequest);
        await _instaConnectSender.Send(commandRequest, cancellationToken);

        return NoContent();
    }
}

