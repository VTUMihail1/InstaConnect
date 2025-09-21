using InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetById;

internal class GetChatMessageByIdQueryHandler : IQueryHandler<GetChatMessageByIdQueryRequest, GetChatMessageByIdQueryResponse>
{
    private readonly IChatMessageService _chatMessageService;
    private readonly IApplicationMapper _applicationMapper;

    public GetChatMessageByIdQueryHandler(
        IChatMessageService chatMessageService,
        IApplicationMapper applicationMapper)
    {
        _chatMessageService = chatMessageService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetChatMessageByIdQueryResponse> Handle(
        GetChatMessageByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetChatMessageByIdQuery>(request);
        var chatMessage = await _chatMessageService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetChatMessageByIdQueryResponse>(chatMessage);

        return response;
    }
}
