namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryResponse(
    PostCommentLikeIdPayload Id,
    UserQueryResponse User,
    DateTimeOffset CreatedAtUtc);
