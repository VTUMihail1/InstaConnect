namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Entities;

public class ChatMessage : IEntity<ChatMessageId>
{
    private ChatMessage()
    {
        Id = new(new(new(string.Empty), new(string.Empty)), string.Empty);
        SenderId = new(string.Empty);
        Content = string.Empty;
    }

    public ChatMessage(
        ChatMessageId id,
        UserId senderId,
        string content,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        SenderId = senderId;
        Content = content;
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public ChatMessageId Id { get; }

    public UserId SenderId { get; }

    public User? Sender { get; private set; }

    public string Content { get; private set; }

    public DateTimeOffset CreatedAtUtc { get; }

    public DateTimeOffset UpdatedAtUtc { get; private set; }

    public void Update(string content, DateTimeOffset updatedAtUtc)
    {
        Content = content;
        UpdatedAtUtc = updatedAtUtc;
    }

    public void AddSender(User sender)
    {
        Sender = sender;
    }
}
