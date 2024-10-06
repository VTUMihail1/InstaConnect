namespace InstaConnect.Shared.Business.Contracts.Emails;

public record UserForgotPasswordTokenCreatedEvent(string Email, string RedirectUrl);
