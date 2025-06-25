using InstaConnect.Messages.Application.Features.Messages.Commands.Add;
using InstaConnect.Messages.Application.Features.Messages.Commands.Delete;
using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAll;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetById;

namespace InstaConnect.Messages.Presentation.Features.Messages.Controllers.v1;

[ApiVersion(MessageRoutes.Version1)]
[Route(MessageRoutes.Resource)]
[Authorize]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class MessageController : ControllerBase
{
    private readonly IApplicationSender _applicationSender;
    private readonly IApplicationMapper _applicationMapper;

    public MessageController(
        IApplicationSender applicationSender,
        IApplicationMapper applicationMapper)
    {
        _applicationSender = applicationSender;
        _applicationMapper = applicationMapper;
    }

    // GET: api/messages
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MessagePaginationQueryResponse>> GetAllAsync(
        GetAllMessagesRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllMessagesQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<MessagePaginationQueryResponse>(queryResponse);

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
        var queryRequest = _applicationMapper.Map<GetMessageByIdQuery>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<MessageQueryResponse>(queryResponse);

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
        var commandRequest = _applicationMapper.Map<AddMessageCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<MessageCommandResponse>(commandResponse);

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
        var commandRequest = _applicationMapper.Map<UpdateMessageCommand>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<MessageCommandResponse>(commandResponse);

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
        var commandRequest = _applicationMapper.Map<DeleteMessageCommand>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}

