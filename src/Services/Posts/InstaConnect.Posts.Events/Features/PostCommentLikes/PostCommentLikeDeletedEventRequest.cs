namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeDeletedEventRequest(
    string Id,
    string CommentId,
    string UserId)
    : IEventRequest;
