using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

public static class ChatProjectionExtensions
{
    public static ProjectionDefinition<Chat, Chat> GetChatProjection(this UserId participantId)
    {
        return Builders<Chat>.Projection.Expression(
            p => new Chat(p.Id.ParticipantOneId.Id.ToLower() == participantId.Id.ToLower()
                                              ? p.Id : new(p.Id.ParticipantTwoId, p.Id.ParticipantOneId),
                          p.CreatedAtUtc));
    }
}
