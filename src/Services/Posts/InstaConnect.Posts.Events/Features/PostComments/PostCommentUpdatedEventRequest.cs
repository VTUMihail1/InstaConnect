namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentUpdatedEventRequest(
        string Id,
        string CommentId,
        string Content,
        string UserId,
        DateTimeOffset UpdatedAtUtc)
    : IEventRequest;
