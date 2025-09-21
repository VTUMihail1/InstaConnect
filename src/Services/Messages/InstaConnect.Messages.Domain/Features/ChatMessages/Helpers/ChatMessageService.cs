using InstaConnect.ChatMessageLikes.Domain.Features.ChatMessageLikes.Abstractions;
using InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetById;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Exceptions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Exceptions;
using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Helpers;
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

        var existingChatMessageCollection = await _chatMessageRepository.GetAllAsync(query, cancellationToken);

        return existingChatMessageCollection;
    }

    public async Task<ChatMessage> GetByIdAsync(GetChatMessageByIdQuery query, CancellationToken cancellationToken)
    {
        var existingChatMessage = await _chatMessageRepository.GetByIdAsync(query.ParticipantOneId, query.ParticipantTwoId, query.MessageId, cancellationToken);

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
        _chatMessageRepository.Add(chatMessage);

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
        _chatMessageRepository.Update(existingChatMessage);

        return existingChatMessage;
    }

    public async Task DeleteAsync(DeleteChatMessageCommand command, CancellationToken cancellationToken)
    {
        var existingChatMessage = await _chatMessageRepository.GetByIdAsync(command.ParticipantOneId, command.ParticipantTwoId, command.MessageId, cancellationToken);

        if (existingChatMessage.IsNull())
        {
            throw new ChatMessageNotFoundException(command.ParticipantOneId, command.ParticipantTwoId, command.MessageId);
        }

        _chatMessageRepository.Delete(existingChatMessage!);
    }
}
