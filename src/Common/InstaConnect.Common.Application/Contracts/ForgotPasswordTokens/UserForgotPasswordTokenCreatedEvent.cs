namespace InstaConnect.Shared.Application.Contracts.ForgotPasswordTokens;

public record UserForgotPasswordTokenCreatedEvent(string Email, string RedirectUrl);
