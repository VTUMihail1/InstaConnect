namespace InstaConnect.Common.Application.Contracts.ForgotPasswordTokens;

public record UserForgotPasswordTokenCreatedEvent(string Email, string RedirectUrl);
