namespace InstaConnect.Emails.Business.Models.Emails;

public record SendForgotPasswordModel(string UserId, string Email, string Token)
{
    private const string TITLE = "Forgot password";

    public string Title => TITLE;
}
