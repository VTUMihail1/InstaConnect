namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeAddedEventRequest(
    string Id,
    string CommentId,
    string UserId,
    DateTimeOffset CreatedAtUtc)
    : IEventRequest;
