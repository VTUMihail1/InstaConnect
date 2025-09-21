using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

public class Chat : IEntity
{
    private Chat()
    {
        ParticipantOneId = string.Empty;
        ParticipantTwoId = string.Empty;
        Messages = [];
    }

    public Chat(
        string participantOneId,
        string participantTwoId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        ParticipantOneId = participantOneId;
        ParticipantTwoId = participantTwoId;
        Messages = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Chat(
        User participantOne,
        User participantTwo,
        ICollection<ChatMessage> messages,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        ParticipantOne = participantOne;
        ParticipantOneId = participantOne.Id;
        ParticipantTwo = participantTwo;
        ParticipantTwoId = participantTwo.Id;
        Messages = messages;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string ParticipantOneId { get; }

    public User? ParticipantOne { get; }

    public string ParticipantTwoId { get; }

    public User? ParticipantTwo { get; }

    public ICollection<ChatMessage> Messages { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}
