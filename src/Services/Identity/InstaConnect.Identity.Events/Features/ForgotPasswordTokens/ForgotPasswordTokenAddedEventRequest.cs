namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenAddedEventRequest(ForgotPasswordTokenIdEventPayload Id, DateTimeOffset ExpiresAt)
    : IEventRequest;
