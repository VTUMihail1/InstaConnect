using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Responses;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageRepository
{
    Task<ChatMessageCollection> GetAllAsync(GetAllChatMessagesQuery query, CancellationToken cancellationToken);

    Task<ChatMessage?> GetByIdAsync(string participantOneId, string participantTwoId, string messageId, CancellationToken cancellationToken);

    void Add(ChatMessage chatMessage);

    void Update(ChatMessage chatMessage);

    void Delete(ChatMessage chatMessage);
}
