using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Helpers;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetAll;

internal class GetAllChatMessagesQueryHandler : IQueryHandler<GetAllChatMessagesQueryRequest, GetAllChatMessagesQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IChatMessageService _chatMessageService;
    private readonly IChatMessageIncludeQueryBuilderFactory _chatMessageIncludeQueryBuilderFactory;

    public GetAllChatMessagesQueryHandler(
        IApplicationMapper applicationMapper,
        IChatMessageService chatMessageService,
        IChatMessageIncludeQueryBuilderFactory chatMessageIncludeQueryBuilderFactory)
    {
        _applicationMapper = applicationMapper;
        _chatMessageService = chatMessageService;
        _chatMessageIncludeQueryBuilderFactory = chatMessageIncludeQueryBuilderFactory;
    }

    public async Task<GetAllChatMessagesQueryResponse> Handle(
        GetAllChatMessagesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _chatMessageIncludeQueryBuilderFactory.Create().WithSender().Build();
        var serviceRequest = _applicationMapper.Map<GetAllChatMessagesQuery>(request).AddInclude(include);
        var collection = await _chatMessageService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllChatMessagesQueryResponse>(collection);

        return response;
    }
}
