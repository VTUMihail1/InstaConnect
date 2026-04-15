namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentQueryResponse(
    string Id,
    string CommentId,
    string UserId,
    string Content,
    UserQueryResponse? User,
    PostQueryResponse? Post,
    bool IsLikedByCurrentUser,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
