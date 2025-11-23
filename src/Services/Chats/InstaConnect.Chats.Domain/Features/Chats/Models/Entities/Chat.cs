namespace InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

public class Chat : IEntity<ChatId>
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

    public Chat(
        ChatId id,
        User participantOne,
        User participantTwo,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        ParticipantOne = participantOne;
        ParticipantTwo = participantTwo;
        Messages = [];
        CreatedAtUtc = createdAtUtc;
    }

    public Chat(
        ChatId id,
        User participantOne,
        User participantTwo,
        IList<ChatMessage> messages,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        ParticipantOne = participantOne;
        ParticipantTwo = participantTwo;
        Messages = messages;
        CreatedAtUtc = createdAtUtc;
    }

    public ChatId Id { get; }

    public User? ParticipantOne { get; private set; }

    public User? ParticipantTwo { get; private set; }

    public ICollection<ChatMessage> Messages { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public void AddParticipantOne(User participantOne)
    {
        ParticipantOne = participantOne;
    }

    public void AddParticipantTwo(User participantTwo)
    {
        ParticipantTwo = participantTwo;
    }

    public void AddMessage(ChatMessage message)
    {
        Messages.Add(message);
    }

    public bool IsNotParticipant(UserId participantId)
    {
        return Id.ParticipantOneId.IsNot(participantId) || Id.ParticipantTwoId.IsNot(participantId);
    }
}
