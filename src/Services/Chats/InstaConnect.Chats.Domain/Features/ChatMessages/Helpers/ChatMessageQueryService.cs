namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

internal class ChatMessageQueryService : IChatMessageQueryService
{
    private readonly IChatQueryRepository _repository;
    private readonly IChatMessageQueryRepository _messageRepository;
    private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
    private readonly IChatMessageIncludeBuilderFactory _messageIncludeBuilderFactory;
    private readonly IChatMessageCollectionResponseFactory _messageCollectionResponseFactory;

    public ChatMessageQueryService(
        IChatQueryRepository repository,
        IChatMessageQueryRepository messageRepository,
        IChatIncludeBuilderFactory includeBuilderFactory,
        IChatMessageIncludeBuilderFactory messageIncludeBuilderFactory,
        IChatMessageCollectionResponseFactory messageCollectionResponseFactory)
    {
        _repository = repository;
        _messageRepository = messageRepository;
        _includeBuilderFactory = includeBuilderFactory;
        _messageIncludeBuilderFactory = messageIncludeBuilderFactory;
        _messageCollectionResponseFactory = messageCollectionResponseFactory;
    }

    public async Task<ChatMessageCollectionResponse> GetAllAsync(GetAllChatMessagesQuery query, CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
        var chat = await _repository.GetByIdAsync(query.Filter.Id, query.CurrentUser, include, cancellationToken);

        if (chat == null)
        {
            throw new ChatNotFoundException(query.Filter.Id);
        }

        var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().Build();
        var chatMessages = await _messageRepository.GetAllAsync(
            query.Filter,
            query.CurrentUser,
            query.Sorting,
            query.Pagination,
            messageInclude,
            cancellationToken);

        var totalCount = await _messageRepository.GetTotalCountAsync(query.Filter, cancellationToken);

        return _messageCollectionResponseFactory.Create(chat, chatMessages, totalCount, query.Pagination);
    }

    public async Task<ChatMessageResponse> GetByIdAsync(GetChatMessageByIdQuery query, CancellationToken cancellationToken)
    {
        var chatNotExists = !await _repository.ExistsByIdAsync(query.Id.Id, cancellationToken);

        if (chatNotExists)
        {
            throw new ChatNotFoundException(query.Id.Id);
        }

        var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
        var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChat(include).Build();
        var chatMessage = await _messageRepository.GetByIdAsync(
            query.Id,
            query.CurrentUser,
            messageInclude,
            cancellationToken);

        if (chatMessage == null)
        {
            throw new ChatMessageNotFoundException(query.Id);
        }

        if (chatMessage.Chat!.IsNotParticipant(query.CurrentUser.Id))
        {
            throw new ChatForbiddenException(query.Id.Id, query.CurrentUser.Id);
        }

        return chatMessage;
    }
}
