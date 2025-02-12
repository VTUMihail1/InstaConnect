namespace InstaConnect.Shared.Application.Contracts.Emails;

public record UserForgotPasswordTokenCreatedEvent(string Email, string RedirectUrl);
