namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryFilter(
    string Id,
    string CommentId,
    string UserId,
    string UserName);
