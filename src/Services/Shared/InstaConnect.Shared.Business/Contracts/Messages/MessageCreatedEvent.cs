namespace InstaConnect.Shared.Business.Contracts.Messages;
public class MessageCreatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string SenderId { get; set; } = string.Empty;

    public string ReceiverId { get; set; } = string.Empty;
}
