using InstaConnect.ChatLikes.Domain.Features.ChatLikes.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

internal class ChatFactory : IChatFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public ChatFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public Chat Create(string participantOneId, string participantTwoId)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var chat = new Chat(
            participantOneId,
            participantTwoId,
            utcNow,
            utcNow);

        return chat;
    }
}
