namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;

internal class GetAllChatsByParticipantQueryHandler : IQueryHandler<GetAllChatsByParticipantQueryRequest, GetAllChatsByParticipantQueryResponse>
{
    private readonly IChatService _chatService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IChatIncludeQueryBuilderFactory _chatIncludeQueryBuilderFactory;

    public GetAllChatsByParticipantQueryHandler(
        IChatService chatService,
        IApplicationMapper applicationMapper,
        IChatIncludeQueryBuilderFactory chatIncludeQueryBuilderFactory)
    {
        _chatService = chatService;
        _applicationMapper = applicationMapper;
        _chatIncludeQueryBuilderFactory = chatIncludeQueryBuilderFactory;
    }

    public async Task<GetAllChatsByParticipantQueryResponse> Handle(
        GetAllChatsByParticipantQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _chatIncludeQueryBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
        var serviceRequest = _applicationMapper.Map<GetAllChatsByParticipantQuery>(request).AddInclude(include);
        var collection = await _chatService.GetAllByParticipantAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllChatsByParticipantQueryResponse>(collection);

        return response;
    }
}
