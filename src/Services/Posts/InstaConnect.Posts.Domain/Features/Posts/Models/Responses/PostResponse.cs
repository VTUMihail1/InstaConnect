using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

public record PostResponse(
    PostId Id,
    UserId UserId,
    string Title,
    string Content,
    UserResponse? User,
    bool IsLikedByCurrentUser,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
