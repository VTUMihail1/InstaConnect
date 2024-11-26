namespace InstaConnect.Shared.Application.Contracts.Emails;

public record UserConfirmEmailTokenCreatedEvent(string Email, string RedirectUrl);
