namespace InstaConnect.Shared.Application.Contracts.EmailConfirmationTokens;

public record UserConfirmEmailTokenCreatedEvent(string Email, string RedirectUrl);
