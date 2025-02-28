using InstaConnect.Messages.Domain.Features.Users.Models.Entities;

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
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
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
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
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

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(string content, DateTimeOffset updatedAt)
    {
        Content = content;
        UpdatedAt = updatedAt;
    }
}
