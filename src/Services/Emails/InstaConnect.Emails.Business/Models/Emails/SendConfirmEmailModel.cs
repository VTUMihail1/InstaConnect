using System.Reflection;

namespace InstaConnect.Emails.Business.Models.Emails;

public record SendConfirmEmailModel(string UserId, string Email, string Token)
{
    private const string TITLE = "Confirm Email";

    public string Title => TITLE;
}
