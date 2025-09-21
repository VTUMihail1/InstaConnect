using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Domain.Events.ForgotPasswordTokens;

public record ForgotPasswordTokenAddedEventRequest(string Id, string Value, DateTimeOffset ExpiresAt)
    : IEventRequest;
