using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Application.Contracts.EmailConfirmationTokens;

public record UserConfirmEmailTokenCreatedEventRequest(string Email, string RedirectUrl)
    : IEventRequest;
