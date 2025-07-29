namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

public record DeletePostCommentLikeCommand(
    string Id,
    string CommentId,
    string CommentLikeId,
    string UserId);
