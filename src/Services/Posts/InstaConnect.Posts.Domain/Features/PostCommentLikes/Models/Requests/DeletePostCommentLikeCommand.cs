namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record DeletePostCommentLikeCommand(
    string Id,
    string CommentId,
    string UserId);
