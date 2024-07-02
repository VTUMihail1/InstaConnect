namespace InstaConnect.Shared.Business.Contracts.Posts;

public class PostUpdatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
