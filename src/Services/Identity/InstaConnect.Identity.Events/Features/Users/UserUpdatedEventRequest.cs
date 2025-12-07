namespace InstaConnect.Identity.Events.Features.Users;

public record UserUpdatedEventRequest(
    string Id,
    string Name,
    string Email,
    string FirstName,
    string LastName,
    string? ProfileImageUrl,
    DateTimeOffset UpdatedAtUtc) : IEventRequest;
