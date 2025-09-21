using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Domain.Events.EmailConfirmationTokens;

public record EmailConfirmationTokenAddedEventRequest(string Id, string Value, DateTimeOffset ExpiresAt)
    : IEventRequest;
