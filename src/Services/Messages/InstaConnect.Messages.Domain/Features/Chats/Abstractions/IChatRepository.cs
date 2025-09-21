using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatRepository
{
    Task<ChatCollection> GetAllByParticipantAsync(GetAllChatsByParticipantQuery query, CancellationToken cancellationToken);

    Task<Chat?> GetByIdAsync(string participantOneId, string participantTwoId, CancellationToken cancellationToken);

    void Add(Chat chat);

    void Update(Chat chat);

    void Delete(Chat chat);
}
