namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record PostCommentApiResponse(
    string Id,
    string CommentId,
    string Content,
    UserApiResponse User,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
