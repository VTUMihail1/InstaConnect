using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

internal class GetAllChatsByParticipantQueryHandler : IQueryHandler<GetAllChatsByParticipantQueryRequest, GetAllChatsByParticipantQueryResponse>
{
    private readonly IChatService _chatService;
    private readonly IApplicationMapper _applicationMapper;

    public GetAllChatsByParticipantQueryHandler(
        IChatService chatService,
        IApplicationMapper applicationMapper)
    {
        _chatService = chatService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetAllChatsByParticipantQueryResponse> Handle(
        GetAllChatsByParticipantQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllChatsByParticipantQuery>(request);
        var collection = await _chatService.GetAllByParticipantAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllChatsByParticipantQueryResponse>(collection);

        return response;
    }
}
