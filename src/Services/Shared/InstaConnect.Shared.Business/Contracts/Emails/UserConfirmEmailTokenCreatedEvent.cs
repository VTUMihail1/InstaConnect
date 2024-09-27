namespace InstaConnect.Shared.Business.Contracts.Emails;

public class UserConfirmEmailTokenCreatedEvent
{
    public UserConfirmEmailTokenCreatedEvent(string email, string userId, string token, string urlTemplate)
    {
        Email = email;
        RedirectUrl = string.Format(urlTemplate, userId, token);
    }

    public string Email { get; }

    public string RedirectUrl { get; }
}
