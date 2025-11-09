namespace InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

public class Chat : IEntity
{
    private readonly IList<ChatMessage> _messages;

    private Chat()
    {
        ParticipantOneId = string.Empty;
        ParticipantTwoId = string.Empty;
        _messages = [];
    }

    public Chat(
        string participantOneId,
        string participantTwoId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        ParticipantOneId = participantOneId;
        ParticipantTwoId = participantTwoId;
        _messages = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Chat(
        User participantOne,
        User participantTwo,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        ParticipantOne = participantOne;
        ParticipantOneId = participantOne.Id;
        ParticipantTwo = participantTwo;
        ParticipantTwoId = participantTwo.Id;
        _messages = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Chat(
        User participantOne,
        User participantTwo,
        IList<ChatMessage> messages,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        ParticipantOne = participantOne;
        ParticipantOneId = participantOne.Id;
        ParticipantTwo = participantTwo;
        ParticipantTwoId = participantTwo.Id;
        _messages = messages;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string ParticipantOneId { get; }

    public User? ParticipantOne { get; private set; }

    public string ParticipantTwoId { get; }

    public User? ParticipantTwo { get; private set; }

    public IReadOnlyCollection<ChatMessage> Messages => _messages.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }

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
        _messages.Add(message);
    }
}
