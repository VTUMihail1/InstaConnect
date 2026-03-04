namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

internal class ChatMessageCommandService : IChatMessageCommandService
{
    private readonly IChatCommandRepository _repository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IChatMessageFactory _messageFactory;
    private readonly IUserCommandRepository _userRepository;
    private readonly IChatMessageCommandRepository _messageRepository;
    private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
    private readonly IChatMessageIncludeBuilderFactory _messageIncludeBuilderFactory;

    public ChatMessageCommandService(
        IChatCommandRepository repository,
        IDateTimeProvider dateTimeProvider,
        IChatMessageFactory messageFactory,
        IUserCommandRepository userRepository,
        IChatMessageCommandRepository messageRepository,
        IChatIncludeBuilderFactory includeBuilderFactory,
        IChatMessageIncludeBuilderFactory messageIncludeBuilderFactory)
    {
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
        _messageFactory = messageFactory;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
        _includeBuilderFactory = includeBuilderFactory;
        _messageIncludeBuilderFactory = messageIncludeBuilderFactory;
    }

    public async Task<ChatMessageId> AddAsync(AddChatMessageCommand command, CancellationToken cancellationToken)
    {
        var sender = await _userRepository.GetByIdAsync(command.SenderId, cancellationToken);

        if (sender == null)
        {
            throw new UserNotFoundException(command.SenderId);
        }

        var chat = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (chat == null)
        {
            throw new ChatNotFoundException(command.Id);
        }

        if (chat.IsNotParticipant(command.SenderId))
        {
            throw new ChatForbiddenException(command.Id, command.SenderId);
        }

        var newChatMessage = _messageFactory.Create(command.Id, command.SenderId, command.Content).AddSender(sender).AddChat(chat);
        await _messageRepository.AddAsync(newChatMessage, cancellationToken);

        return newChatMessage.Id;
    }

    public async Task<ChatMessageId> UpdateAsync(UpdateChatMessageCommand command, CancellationToken cancellationToken)
    {
        var chatNotExists = await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

        if (chatNotExists)
        {
            throw new ChatNotFoundException(command.Id.Id);
        }

        var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
        var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChat(include).Build();
        var chatMessage = await _messageRepository.GetByIdAsync(command.Id, messageInclude, cancellationToken);

        if (chatMessage == null)
        {
            throw new ChatMessageNotFoundException(command.Id);
        }

        if (chatMessage.SenderId.IsNot(command.SenderId))
        {
            throw new ChatMessageForbiddenException(command.Id, command.SenderId);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        chatMessage.Update(command.Content, utcNow);
        await _messageRepository.UpdateAsync(chatMessage, cancellationToken);

        return chatMessage.Id;
    }

    public async Task DeleteAsync(DeleteChatMessageCommand command, CancellationToken cancellationToken)
    {
        var chatNotExists = await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

        if (chatNotExists)
        {
            throw new ChatNotFoundException(command.Id.Id);
        }

        var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
        var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChat(include).Build();
        var chatMessage = await _messageRepository.GetByIdAsync(command.Id, messageInclude, cancellationToken);

        if (chatMessage == null)
        {
            throw new ChatMessageNotFoundException(command.Id);
        }

        if (chatMessage.SenderId.IsNot(command.SenderId))
        {
            throw new ChatMessageForbiddenException(command.Id, command.SenderId);
        }

        await _messageRepository.DeleteAsync(chatMessage, cancellationToken);
    }
}
