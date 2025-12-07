using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;
internal class ChatMessageService : IChatMessageService
{
    private readonly IChatRepository _chatRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IChatMessageFactory _chatMessageFactory;
    private readonly IChatMessageRepository _chatMessageRepository;

    public ChatMessageService(
        IChatRepository chatRepository,
        IDateTimeProvider dateTimeProvider,
        IChatMessageFactory chatMessageFactory,
        IChatMessageRepository chatMessageRepository)
    {
        _chatRepository = chatRepository;
        _dateTimeProvider = dateTimeProvider;
        _chatMessageFactory = chatMessageFactory;
        _chatMessageRepository = chatMessageRepository;
    }

    public async Task<ChatMessageCollection> GetAllAsync(GetAllChatMessagesQuery query, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(query.Filter.Id, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(query.Filter.Id);
        }

        if (existingChat!.IsNotParticipant(query.Filter.UserId))
        {
            throw new ChatForbiddenException(query.Filter.Id, query.Filter.UserId);
        }

        var existingChatMessageCollection = await _chatMessageRepository.GetAllAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingChatMessageCollection;
    }

    public async Task<ChatMessage> GetByIdAsync(GetChatMessageByIdQuery query, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(query.Id.Id, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(query.Id.Id);
        }

        if (existingChat!.IsNotParticipant(query.UserId))
        {
            throw new ChatForbiddenException(query.Id.Id, query.UserId);
        }

        var existingChatMessage = await _chatMessageRepository.GetByIdAsync(
            query.Id,
            query.Include,
            cancellationToken);

        if (existingChatMessage.IsNull())
        {
            throw new ChatMessageNotFoundException(query.Id);
        }

        return existingChatMessage!;
    }

    public async Task<ChatMessage> AddAsync(AddChatMessageCommand command, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(command.Id);
        }

        if (existingChat!.IsNotParticipant(command.SenderId))
        {
            throw new ChatForbiddenException(command.Id, command.SenderId);
        }

        var chatMessage = _chatMessageFactory.Create(command.Id, command.SenderId, command.Content);
        await _chatMessageRepository.AddAsync(chatMessage, cancellationToken);

        return chatMessage;
    }

    public async Task<ChatMessage> UpdateAsync(UpdateChatMessageCommand command, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(command.Id.Id, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(command.Id.Id);
        }

        if (existingChat!.IsNotParticipant(command.SenderId))
        {
            throw new ChatForbiddenException(command.Id.Id, command.SenderId);
        }

        var existingChatMessage = await _chatMessageRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingChatMessage.IsNull())
        {
            throw new ChatMessageNotFoundException(command.Id);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        existingChatMessage!.Update(command.Content, utcNow);
        await _chatMessageRepository.UpdateAsync(existingChatMessage, cancellationToken);

        return existingChatMessage;
    }

    public async Task DeleteAsync(DeleteChatMessageCommand command, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(command.Id.Id, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(command.Id.Id);
        }

        if (existingChat!.IsNotParticipant(command.SenderId))
        {
            throw new ChatForbiddenException(command.Id.Id, command.SenderId);
        }

        var existingChatMessage = await _chatMessageRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingChatMessage.IsNull())
        {
            throw new ChatMessageNotFoundException(command.Id);
        }

        await _chatMessageRepository.DeleteAsync(existingChatMessage!, cancellationToken);
    }
}
