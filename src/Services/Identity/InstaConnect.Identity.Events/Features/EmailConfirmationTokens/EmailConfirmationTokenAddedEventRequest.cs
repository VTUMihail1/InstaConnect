namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenAddedEventRequest(string Id, string Value, DateTimeOffset ExpiresAt)
    : IEventRequest;
