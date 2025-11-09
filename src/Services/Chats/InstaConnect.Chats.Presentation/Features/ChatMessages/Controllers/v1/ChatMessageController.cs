using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Controllers.v1;

[ApiVersion(ChatMessageRoutes.Version1)]
[Route(ChatMessageRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class ChatMessageController : ControllerBase
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public ChatMessageController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // GET: api/participants/5f0f2dd0-e957-4d72-8141-767a36fc6e95/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95/messages
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllChatMessagesApiResponse>> GetAllAsync(
        GetAllChatMessagesApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllChatMessagesQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetAllChatMessagesApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/participants/current/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(ChatMessageRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetChatMessageByIdApiResponse>> GetByIdAsync(
        GetChatMessageByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetChatMessageByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetChatMessageByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/participants/current/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95/messages
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddChatMessageApiResponse>> AddAsync(
        AddChatMessageApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddChatMessageCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<AddChatMessageApiResponse>(commandResponse);

        return Ok(response);
    }

    // PUT: api/participants/current/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut(ChatMessageRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UpdateChatMessageApiResponse>> UpdateAsync(
        UpdateChatMessageApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<UpdateChatMessageCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<UpdateChatMessageApiResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/participants/current/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(ChatMessageRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeleteChatMessageApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteChatMessageCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
