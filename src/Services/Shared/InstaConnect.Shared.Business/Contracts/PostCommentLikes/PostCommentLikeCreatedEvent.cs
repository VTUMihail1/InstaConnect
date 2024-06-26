namespace InstaConnect.Shared.Business.Contracts.PostCommentLikes;

public class PostCommentLikeCreatedEvent
{
    public string Id { get; set; }

    public string PostCommentId { get; set; }

    public string UserId { get; set; }
}
