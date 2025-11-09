namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageFactory
{
    public ChatMessage Create(string participantOneId, string participantTwoId, string content);
}
