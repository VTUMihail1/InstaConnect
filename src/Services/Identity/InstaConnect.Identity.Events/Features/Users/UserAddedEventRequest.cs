namespace InstaConnect.Identity.Events.Features.Users;
public record UserAddedEventRequest(
    string Id,
    string Name,
    string Email,
    string FirstName,
    string LastName,
    string? ProfileImageUrl,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc)
    : IEventRequest;
