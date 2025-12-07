namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryResponse(
    string Id,
    string Title,
    string Content,
    UserQueryResponse User,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
