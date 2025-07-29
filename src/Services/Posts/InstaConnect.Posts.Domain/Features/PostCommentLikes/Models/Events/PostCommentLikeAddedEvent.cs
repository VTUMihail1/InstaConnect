namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Events;

public record PostCommentLikeAddedEvent(
        string Id,
        string CommentId,
        string CommentLikeId,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
