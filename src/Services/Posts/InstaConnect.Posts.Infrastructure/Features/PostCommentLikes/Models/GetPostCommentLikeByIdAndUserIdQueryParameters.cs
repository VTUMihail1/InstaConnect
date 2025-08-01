namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record GetPostCommentLikeByIdAndUserIdQueryParameters(
    string Id,
    string CommentId,
    string UserId);
