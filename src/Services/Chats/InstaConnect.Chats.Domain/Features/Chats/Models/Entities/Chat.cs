namespace InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

public class Chat : IEntityWithId<ChatId>
{
    private Chat()
    {
        Id = new(new(string.Empty), new(string.Empty));
        Messages = [];
    }

    public Chat(
        ChatId id,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        Messages = [];
        CreatedAtUtc = createdAtUtc;
    }

    public ChatId Id { get; }

    public User? ParticipantOne { get; private set; }

    public User? ParticipantTwo { get; private set; }

    public ICollection<ChatMessage> Messages { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public Chat AddParticipantOne(User? participantOne)
    {
        ParticipantOne = participantOne;

        return this;
    }

    public Chat AddParticipantTwo(User? participantTwo)
    {
        ParticipantTwo = participantTwo;

        return this;
    }

    public Chat AddMessage(ChatMessage message)
    {
        Messages.Add(message);

        return this;
    }

    public bool IsNotParticipant(UserId participantId)
    {
        return Id.ParticipantOneId.IsNot(participantId) || Id.ParticipantTwoId.IsNot(participantId);
    }
}
