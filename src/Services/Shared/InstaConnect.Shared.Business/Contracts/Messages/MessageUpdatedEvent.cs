namespace InstaConnect.Shared.Business.Contracts.Messages;

public class MessageUpdatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
