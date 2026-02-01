namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeApiResponse(
    string Id,
    string CommentId,
    string UserId,
    UserApiResponse? User,
    PostCommentApiResponse? PostComment,
    DateTimeOffset CreatedAtUtc);
