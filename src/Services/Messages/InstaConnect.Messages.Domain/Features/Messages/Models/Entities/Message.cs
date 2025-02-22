using InstaConnect.Messages.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Domain.Abstractions;

using NSubstitute;

namespace InstaConnect.Messages.Domain.Features.Messages.Models.Entities;

public class Message : IBaseEntity, IAuditableInfo
{
    private Message()
    {
        Id = string.Empty;
        Content = string.Empty;
        SenderId = string.Empty;
        ReceiverId = string.Empty;
    }

    public Message(
        string id,
        string content,
        string senderId,
        string receiverId,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Content = content;
        SenderId = senderId;
        ReceiverId = receiverId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Message(
        string id,
        string content,
        User sender,
        User receiver,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Content = content;
        Sender = sender;
        SenderId = sender.Id;
        Receiver = receiver;
        ReceiverId = receiver.Id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string Content { get; private set; }

    public string SenderId { get; }

    public User? Sender { get; }

    public string ReceiverId { get; }

    public User? Receiver { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    public void Update(string content, DateTime updatedAt)
    {
        Content = content;
        UpdatedAt = updatedAt;
    }
}
