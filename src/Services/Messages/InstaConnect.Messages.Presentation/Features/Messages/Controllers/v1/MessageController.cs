using Asp.Versioning;

using InstaConnect.Messages.Application.Features.Messages.Commands.Add;
using InstaConnect.Messages.Application.Features.Messages.Commands.Delete;
using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAll;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetById;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.Features.Messages.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Presentation.Utilities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Messages.Presentation.Features.Messages.Controllers.v1;

[ApiVersion(MessageRoutes.Version1)]
[Route(MessageRoutes.Resource)]
[Authorize]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class MessageController : ControllerBase
{
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public MessageController(
        IInstaConnectSender instaConnectSender,
        IInstaConnectMapper instaConnectMapper)
    {
        _instaConnectSender = instaConnectSender;
        _instaConnectMapper = instaConnectMapper;
    }

    // GET: api/messages
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MessagePaginationQueryResponse>> GetAllAsync(
        GetAllMessagesRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllMessagesQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessagePaginationQueryResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(MessageRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageQueryResponse>> GetByIdAsync(
        GetMessageByIdRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _instaConnectMapper.Map<GetMessageByIdQuery>(request);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageQueryResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/messages
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageCommandResponse>> AddAsync(
        AddMessageRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<AddMessageCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageCommandResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut(MessageRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageCommandResponse>> UpdateAsync(
        UpdateMessageRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<UpdateMessageCommand>(request);
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, cancellationToken);
        var response = _instaConnectMapper.Map<MessageCommandResponse>(commandResponse);

        return Ok(response);
    }

    //DELETE: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(MessageRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeleteMessageRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<DeleteMessageCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}

