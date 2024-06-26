namespace InstaConnect.Shared.Business.Contracts.Messages;
public class MessageCreatedEvent
{
    public string Id { get; set; }

    public string Content { get; set; }

    public string SenderId { get; set; }

    public string ReceiverId { get; set; }
}
