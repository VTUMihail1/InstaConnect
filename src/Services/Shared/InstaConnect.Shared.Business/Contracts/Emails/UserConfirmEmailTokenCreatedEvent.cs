namespace InstaConnect.Shared.Business.Contracts.Emails;

public record UserConfirmEmailTokenCreatedEvent(string UserId, string Email, string Token);
