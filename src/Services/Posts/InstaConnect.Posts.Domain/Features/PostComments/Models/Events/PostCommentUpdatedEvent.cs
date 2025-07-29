namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Events;

public record PostCommentUpdatedEvent(
        string Id,
        string CommentId,
        string Content,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
