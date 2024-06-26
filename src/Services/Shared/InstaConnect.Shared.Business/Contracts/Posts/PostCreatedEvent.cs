namespace InstaConnect.Shared.Business.Contracts.Posts;

public class PostCreatedEvent
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string UserId { get; set; }
}
