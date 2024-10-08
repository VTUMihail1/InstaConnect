﻿using Asp.Versioning;
using InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Web.Features.Messages.Models.Requests;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Messages.Web.Features.Messages.Controllers.v1;

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

    // GET: api/messages
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MessagePaginationCollectionQueryResponse>> GetAllAsync(
        GetAllMessagesRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var queryRequest = _instaConnectMapper.Map<GetAllMessagesQuery>((currentUser, request));
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessagePaginationCollectionQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageQueryViewResponse>> GetByIdAsync(
        GetMessageByIdRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var queryRequest = _instaConnectMapper.Map<GetMessageByIdQuery>((currentUser, request));
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageQueryViewResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/messages
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageCommandViewResponse>> AddAsync(AddMessageRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<AddMessageCommand>((currentUser, request));
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageCommandViewResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageCommandViewResponse>> UpdateAsync(UpdateMessageRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<UpdateMessageCommand>((currentUser, request));
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageCommandViewResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(DeleteMessageRequest request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<DeleteMessageCommand>((currentUser, request));
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}

