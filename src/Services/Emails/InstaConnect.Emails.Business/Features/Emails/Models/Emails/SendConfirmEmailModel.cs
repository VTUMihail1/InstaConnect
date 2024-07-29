namespace InstaConnect.Emails.Business.Features.Emails.Models.Emails;

public record SendConfirmEmailModel(string UserId, string Email, string Token)
{
    private const string TITLE = "Confirm Email";

    public string Title => TITLE;
}
