namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenAddedEventRequest(
    string Id,
    string Value,
    DateTimeOffset ExpiresAtUtc,
    DateTimeOffset CreatedAtUtc)
    : IEventRequest;
