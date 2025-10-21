using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;

public class ChatMessage : IEntity
{
    private ChatMessage()
    {
        MessageId = string.Empty;
        ParticipantOneId = string.Empty;
        ParticipantTwoId = string.Empty;
        SenderId = string.Empty;
        Content = string.Empty;
    }

    public ChatMessage(
        string participantOneId,
        string participantTwoId,
        string messageId,
        string senderId,
        string content,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        ParticipantOneId = participantOneId;
        ParticipantTwoId = participantTwoId;
        MessageId = messageId;
        SenderId = senderId;
        Content = content;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public ChatMessage(
        string participantOneId,
        string participantTwoId,
        string messageId,
        User sender,
        string content,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        ParticipantOneId = participantOneId;
        ParticipantTwoId = participantTwoId;
        MessageId = messageId;
        SenderId = sender.Id;
        Sender = sender;
        Content = content;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string MessageId { get; }

    public string ParticipantOneId { get; }

    public string ParticipantTwoId { get; }

    public string SenderId { get; }

    public User? Sender { get; private set; }

    public string Content { get; private set; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(string content, DateTimeOffset updatedAt)
    {
        Content = content;
        UpdatedAt = updatedAt;
    }

    public bool IsOwnedBySender(string senderId)
    {
        var isOwnedBySender = SenderId.EqualsOrdinalIgnoreCase(senderId);

        return isOwnedBySender;
    }

    public bool IsNotOwnedBySender(string senderId)
    {
        var isNotOwnedBySender = !IsOwnedBySender(senderId);

        return isNotOwnedBySender;
    }

    public void AddSender(User sender)
    {
        Sender = sender;
    }
}
