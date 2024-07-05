namespace InstaConnect.Shared.Business.Contracts.Emails;

public class UserForgotPasswordTokenCreatedEvent
{
    public string UserId { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;
}
