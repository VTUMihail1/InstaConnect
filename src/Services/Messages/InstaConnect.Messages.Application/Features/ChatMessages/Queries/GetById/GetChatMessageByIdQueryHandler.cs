using InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetById;

internal class GetChatMessageByIdQueryHandler : IQueryHandler<GetChatMessageByIdQueryRequest, GetChatMessageByIdQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IChatMessageService _chatMessageService;
    private readonly IChatMessageIncludeQueryBuilderFactory _chatMessageIncludeQueryBuilderFactory;

    public GetChatMessageByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IChatMessageService chatMessageService,
        IChatMessageIncludeQueryBuilderFactory chatMessageIncludeQueryBuilderFactory)
    {
        _applicationMapper = applicationMapper;
        _chatMessageService = chatMessageService;
        _chatMessageIncludeQueryBuilderFactory = chatMessageIncludeQueryBuilderFactory;
    }

    public async Task<GetChatMessageByIdQueryResponse> Handle(
        GetChatMessageByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _chatMessageIncludeQueryBuilderFactory.Create().WithSender().Build();
        var serviceRequest = _applicationMapper.Map<GetChatMessageByIdQuery>(request).AddInclude(include);
        var chatMessage = await _chatMessageService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetChatMessageByIdQueryResponse>(chatMessage);

        return response;
    }
}
