namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenAddedEventRequest(string Id, string Value, DateTimeOffset ExpiresAt)
    : IEventRequest;
