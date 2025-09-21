using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;

namespace InstaConnect.ChatMessageLikes.Domain.Features.ChatMessageLikes.Abstractions;

public interface IChatMessageFactory
{
    public ChatMessage Create(string participantOneId, string participantTwoId, string content);
}
