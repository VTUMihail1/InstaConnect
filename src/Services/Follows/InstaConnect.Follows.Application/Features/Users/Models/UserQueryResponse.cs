namespace InstaConnect.Follows.Application.Features.Users.Models;

public record UserQueryResponse(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string? ProfileImageUrl,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
