namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

internal class ChatQueryService : IChatQueryService
{
    private readonly IChatQueryRepository _repository;
    private readonly IUserQueryRepository _userRepository;
    private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
    private readonly IChatCollectionResponseFactory _collectionResponseFactory;

    public ChatQueryService(
        IChatQueryRepository repository,
        IUserQueryRepository userRepository,
        IChatIncludeBuilderFactory includeBuilderFactory,
        IChatCollectionResponseFactory collectionResponseFactory)
    {
        _repository = repository;
        _userRepository = userRepository;
        _includeBuilderFactory = includeBuilderFactory;
        _collectionResponseFactory = collectionResponseFactory;
    }

    public async Task<ChatCollectionResponse> GetAllAsync(GetAllChatsQuery query, CancellationToken cancellationToken)
    {
        var participantOne = await _userRepository.GetByIdAsync(query.Filter.ParticipantOneId, query.CurrentUser, cancellationToken);

        if (participantOne == null)
        {
            throw new UserNotFoundException(query.Filter.ParticipantOneId);
        }

        var include = _includeBuilderFactory.Create().WithParticipantTwo().Build();
        var chats = await _repository.GetAllAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            include,
            cancellationToken);

        var totalCount = await _repository.GetTotalCountAsync(query.Filter, cancellationToken);

        return _collectionResponseFactory.Create(participantOne, chats, totalCount, query.Pagination);
    }

    public async Task<ChatResponse> GetByIdAsync(GetChatByIdQuery query, CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
        var chat = await _repository.GetByIdAsync(
            query.Id,
            query.CurrentUser,
            include,
            cancellationToken);

        if (chat == null)
        {
            throw new ChatNotFoundException(query.Id);
        }

        return chat;
    }
}
