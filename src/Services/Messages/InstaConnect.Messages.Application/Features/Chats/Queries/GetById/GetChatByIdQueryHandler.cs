using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

internal class GetChatByIdQueryHandler : IQueryHandler<GetChatByIdQueryRequest, GetChatByIdQueryResponse>
{
    private readonly IChatService _chatService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IChatIncludeQueryBuilderFactory _chatIncludeQueryBuilderFactory;

    public GetChatByIdQueryHandler(
        IChatService chatService,
        IApplicationMapper applicationMapper,
        IChatIncludeQueryBuilderFactory chatIncludeQueryBuilderFactory)
    {
        _chatService = chatService;
        _applicationMapper = applicationMapper;
        _chatIncludeQueryBuilderFactory = chatIncludeQueryBuilderFactory;
    }

    public async Task<GetChatByIdQueryResponse> Handle(
        GetChatByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _chatIncludeQueryBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
        var serviceRequest = _applicationMapper.Map<GetChatByIdQuery>(request).AddInclude(include);
        var chat = await _chatService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetChatByIdQueryResponse>(chat);

        return response;
    }
}
