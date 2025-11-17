namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenAddedEventRequest(EmailConfirmationTokenIdEventPayload Id, DateTimeOffset ExpiresAtUtc)
    : IEventRequest;
