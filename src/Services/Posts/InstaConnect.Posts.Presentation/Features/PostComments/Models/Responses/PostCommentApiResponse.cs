namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record PostCommentApiResponse(
    string Id,
    string CommentId,
    string UserId,
    string Content,
    UserApiResponse? User,
    PostApiResponse? Post,
    bool IsLikedByCurrentUser,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
