using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetAll;

internal class GetAllChatMessagesQueryHandler : IQueryHandler<GetAllChatMessagesQueryRequest, GetAllChatMessagesQueryResponse>
{
    private readonly IChatMessageService _chatMessageService;
    private readonly IApplicationMapper _applicationMapper;

    public GetAllChatMessagesQueryHandler(
        IChatMessageService chatMessageService,
        IApplicationMapper applicationMapper)
    {
        _chatMessageService = chatMessageService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetAllChatMessagesQueryResponse> Handle(
        GetAllChatMessagesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllChatMessagesQuery>(request);
        var collection = await _chatMessageService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllChatMessagesQueryResponse>(collection);

        return response;
    }
}
