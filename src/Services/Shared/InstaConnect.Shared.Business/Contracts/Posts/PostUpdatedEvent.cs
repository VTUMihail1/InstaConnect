namespace InstaConnect.Shared.Business.Contracts.Posts;

public class PostUpdatedEvent
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
}
