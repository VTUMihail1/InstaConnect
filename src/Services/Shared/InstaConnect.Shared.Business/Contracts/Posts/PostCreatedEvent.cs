namespace InstaConnect.Shared.Business.Contracts.Posts;

public class PostCreatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
}
