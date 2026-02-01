namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenEventRequest(
    string Id,
    string Value,
    DateTimeOffset ExpiresAtUtc,
    DateTimeOffset CreatedAtUtc);
