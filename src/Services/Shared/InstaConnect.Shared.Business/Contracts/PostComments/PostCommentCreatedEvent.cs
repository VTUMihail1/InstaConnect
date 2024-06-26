namespace InstaConnect.Shared.Business.Contracts.PostComments;

public class PostCommentCreatedEvent
{
    public string Id { get; set; }

    public string Content { get; set; }

    public string PostId { get; set; }

    public string UserId { get; set; }
}
