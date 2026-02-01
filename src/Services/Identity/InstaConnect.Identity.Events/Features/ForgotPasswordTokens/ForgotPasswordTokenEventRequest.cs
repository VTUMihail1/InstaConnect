namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenEventRequest(
    string Id,
    string Value,
    DateTimeOffset ExpiresAtUtc,
    DateTimeOffset CreatedAtUtc);
