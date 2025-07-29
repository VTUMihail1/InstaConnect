namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Events;

public record PostCommentLikeDeletedEvent(
    string Id,
    string CommentId,
    string CommentLikeId);
