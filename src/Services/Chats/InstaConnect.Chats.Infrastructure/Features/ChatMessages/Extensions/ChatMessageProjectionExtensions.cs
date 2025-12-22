using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

public static class ChatMessageProjectionExtensions
{
    public static ProjectionDefinition<ChatMessage, ChatMessage> GetChatMessageProjection(this ChatId id)
    {
        return Builders<ChatMessage>.Projection.Expression(
            c => new ChatMessage(c.Id.Id.ParticipantOneId.Id.ToLower() == id.ParticipantOneId.Id.ToLower()
                                  ? c.Id : new(
                                               new(
                                                   c.Id.Id.ParticipantTwoId,
                                                   c.Id.Id.ParticipantOneId),
                                               c.Id.MessageId),
                                    c.SenderId,
                                    c.Content,
                                    c.CreatedAtUtc,
                                    c.UpdatedAtUtc));
    }
}
