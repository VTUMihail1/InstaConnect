namespace InstaConnect.Follows.Presentation.Features.Users.Models.Responses;

public record UserApiResponse(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string? ProfileImageUrl,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
