namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryResponse(
    string Id,
    string CommentId,
    UserQueryResponse User,
    DateTimeOffset CreatedAtUtc);
