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
        var existingChat = await _chatRepository.GetByIdAsync(query.Filter.ParticipantOneId, query.Filter.ParticipantTwoId, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(query.Filter.ParticipantOneId, query.Filter.ParticipantTwoId);
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
        var existingChatMessage = await _chatMessageRepository.GetByIdAsync(
            query.ParticipantOneId,
            query.ParticipantTwoId,
            query.MessageId,
            query.Include,
            cancellationToken);

        if (existingChatMessage.IsNull())
        {
            throw new ChatMessageNotFoundException(query.ParticipantOneId, query.ParticipantTwoId, query.MessageId);
        }

        return existingChatMessage!;
    }

    public async Task<ChatMessage> AddAsync(AddChatMessageCommand command, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(command.ParticipantOneId, command.ParticipantTwoId, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(command.ParticipantOneId, command.ParticipantTwoId);
        }

        var chatMessage = _chatMessageFactory.Create(command.ParticipantOneId, command.ParticipantTwoId, command.Content);
        await _chatMessageRepository.AddAsync(chatMessage, cancellationToken);

        return chatMessage;
    }

    public async Task<ChatMessage> UpdateAsync(UpdateChatMessageCommand command, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(command.ParticipantOneId, command.ParticipantTwoId, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(command.ParticipantOneId, command.ParticipantTwoId);
        }

        var existingChatMessage = await _chatMessageRepository.GetByIdAsync(command.ParticipantOneId, command.ParticipantTwoId, command.MessageId, cancellationToken);

        if (existingChatMessage.IsNull())
        {
            throw new ChatMessageNotFoundException(command.ParticipantOneId, command.ParticipantTwoId, command.MessageId);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        existingChatMessage!.Update(command.Content, utcNow);
        await _chatMessageRepository.UpdateAsync(existingChatMessage, cancellationToken);

        return existingChatMessage;
    }

    public async Task DeleteAsync(DeleteChatMessageCommand command, CancellationToken cancellationToken)
    {
        var existingChatMessage = await _chatMessageRepository.GetByIdAsync(command.ParticipantOneId, command.ParticipantTwoId, command.MessageId, cancellationToken);

        if (existingChatMessage.IsNull())
        {
            throw new ChatMessageNotFoundException(command.ParticipantOneId, command.ParticipantTwoId, command.MessageId);
        }

        await _chatMessageRepository.DeleteAsync(existingChatMessage!, cancellationToken);
    }
}
