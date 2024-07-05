namespace InstaConnect.Shared.Business.Contracts.Emails;

public class UserConfirmEmailTokenCreatedEvent
{
    public string UserId { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;
}
