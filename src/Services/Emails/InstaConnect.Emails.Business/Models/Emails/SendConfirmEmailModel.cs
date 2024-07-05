using System.Reflection;

namespace InstaConnect.Emails.Business.Models.Emails;

public class SendConfirmEmailModel
{
    private const string TITLE = "Confirm Email";


    public string UserId { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public string Title => TITLE;
}
