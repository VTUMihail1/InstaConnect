namespace InstaConnect.Common.Application.Contracts.EmailConfirmationTokens;

public record UserConfirmEmailTokenCreatedEvent(string Email, string RedirectUrl);
