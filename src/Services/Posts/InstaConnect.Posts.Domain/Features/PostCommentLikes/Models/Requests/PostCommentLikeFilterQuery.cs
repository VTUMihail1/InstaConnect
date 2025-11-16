namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeFilterQuery(
    PostCommentId CommentId,
    Name UserName);
