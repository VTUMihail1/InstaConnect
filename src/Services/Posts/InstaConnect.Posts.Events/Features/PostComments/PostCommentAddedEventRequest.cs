namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentAddedEventRequest(
        string Id,
        string CommentId,
        string Content,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
