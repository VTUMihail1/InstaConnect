using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryResponse(
    PostIdPayload Id,
    string Title,
    string Content,
    UserQueryResponse User,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
