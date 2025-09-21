using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

internal class GetChatByIdQueryHandler : IQueryHandler<GetChatByIdQueryRequest, GetChatByIdQueryResponse>
{
    private readonly IChatService _chatService;
    private readonly IApplicationMapper _applicationMapper;

    public GetChatByIdQueryHandler(
        IChatService chatService,
        IApplicationMapper applicationMapper)
    {
        _chatService = chatService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetChatByIdQueryResponse> Handle(
        GetChatByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetChatByIdQuery>(request);
        var chat = await _chatService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetChatByIdQueryResponse>(chat);

        return response;
    }
}
