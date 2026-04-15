namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryResponse(
    string Id,
    string UserId,
    string Title,
    string Content,
    UserQueryResponse? User,
    bool IsLikedByCurrentUser,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
