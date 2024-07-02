namespace InstaConnect.Shared.Business.Contracts.PostCommentLikes;

public class PostCommentLikeCreatedEvent
{
    public string Id { get; set; } = string.Empty;

    public string PostCommentId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
}
