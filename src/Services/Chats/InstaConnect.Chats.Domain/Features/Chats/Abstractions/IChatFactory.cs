namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatFactory
{
    public Chat Create(string participantOneId, string participantTwoId);
}
