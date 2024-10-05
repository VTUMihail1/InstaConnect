namespace InstaConnect.Shared.Business.Contracts.Emails;

public record UserConfirmEmailTokenCreatedEvent(string Email, string RedirectUrl);
