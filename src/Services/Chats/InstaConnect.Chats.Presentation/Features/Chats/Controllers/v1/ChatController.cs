using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

namespace InstaConnect.Chats.Presentation.Features.Chats.Controllers.v1;

[ApiVersion(ChatRoutes.Version1)]
[Route(ChatRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class ChatController : ControllerBase
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public ChatController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // GET: api/participants/5f0f2dd0-e957-4d72-8141-767a36fc6e95/chats
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAllChatsByParticipantApiResponse>> GetAllByParticipantAsync(
        GetAllChatsByParticipantApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetAllChatsByParticipantQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetAllChatsByParticipantApiResponse>(queryResponse);

        return Ok(response);
    }

    // GET: api/participants/current/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpGet(ChatRoutes.Id)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetChatByIdApiResponse>> GetByIdAsync(
        GetChatByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var queryRequest = _applicationMapper.Map<GetChatByIdQueryRequest>(request);
        var queryResponse = await _applicationSender.SendAsync(queryRequest, cancellationToken);
        var response = _applicationMapper.Map<GetChatByIdApiResponse>(queryResponse);

        return Ok(response);
    }

    // POST: api/participants/current/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPost(ChatRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddChatApiResponse>> AddAsync(
        AddChatApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddChatCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);
        var response = _applicationMapper.Map<AddChatApiResponse>(commandResponse);

        return Ok(response);
    }

    // DELETE: api/participants/current/chats/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete(ChatRoutes.Id)]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(
        DeleteChatApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteChatCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
