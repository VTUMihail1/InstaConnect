namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeFilterQuery(
    string Id,
    string CommentId,
    string UserName);
