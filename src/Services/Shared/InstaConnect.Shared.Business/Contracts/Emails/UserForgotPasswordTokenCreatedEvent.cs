namespace InstaConnect.Shared.Business.Contracts.Emails;

public record UserForgotPasswordTokenCreatedEvent(string UserId, string Email, string Token);
