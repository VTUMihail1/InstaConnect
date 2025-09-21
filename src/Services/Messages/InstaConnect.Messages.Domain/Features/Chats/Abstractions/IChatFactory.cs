using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

namespace InstaConnect.ChatLikes.Domain.Features.ChatLikes.Abstractions;

public interface IChatFactory
{
    public Chat Create(string participantOneId, string participantTwoId);
}
