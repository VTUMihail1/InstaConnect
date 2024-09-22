namespace InstaConnect.Shared.Business.Contracts.Emails;

public class UserConfirmEmailTokenCreatedEvent
{
    public UserConfirmEmailTokenCreatedEvent(string email, string userId, string token, string url, string urlTemplate)
    {
        Email = email;
        RedirectUrl = string.Format(urlTemplate, url, userId, token);
    }

    public string Email { get; }

    public string RedirectUrl { get; }
}
