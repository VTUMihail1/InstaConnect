namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserDetailsApiResponse(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string Email,
    string? ProfileImageUrl,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
