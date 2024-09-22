namespace InstaConnect.Shared.Business.Contracts.Emails;

public class UserForgotPasswordTokenCreatedEvent
{
    public UserForgotPasswordTokenCreatedEvent(string email, string userId, string token, string url, string urlTemplate)
    {
        Email = email;
        RedirectUrl = string.Format(urlTemplate, url, userId, token);
    }

    public string Email { get; }

    public string RedirectUrl { get; }
}

