namespace InstaConnect.Shared.Business.Contracts.PostComments;

public class PostCommentUpdatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
