namespace InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;

public record ChatId(UserId ParticipantOneId, UserId ParticipantTwoId) : IEntityId
{
    public bool HasUser(UserId participantId)
    {
        return ParticipantOneId == participantId || ParticipantTwoId == participantId;
    }

    public bool Is(ChatId id)
    {
        return ParticipantOneId == id.ParticipantOneId && ParticipantTwoId == id.ParticipantTwoId &&
               ParticipantTwoId == id.ParticipantOneId && ParticipantOneId == id.ParticipantTwoId;
    }
}
