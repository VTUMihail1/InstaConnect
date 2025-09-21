using InstaConnect.ChatMessageLikes.Domain.Features.ChatMessageLikes.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Helpers;

internal class ChatMessageFactory : IChatMessageFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ChatMessageFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public ChatMessage Create(string participantOneId, string participantTwoId, string content)
    {
        var messageId = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var chatMessage = new ChatMessage(
            participantOneId,
            participantTwoId,
            messageId,
            participantOneId,
            content,
            utcNow,
            utcNow);

        return chatMessage;
    }
}
