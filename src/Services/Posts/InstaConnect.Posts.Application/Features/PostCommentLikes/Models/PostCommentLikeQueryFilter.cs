namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryFilter(
    string Id,
    string CommentId,
    string UserName);
