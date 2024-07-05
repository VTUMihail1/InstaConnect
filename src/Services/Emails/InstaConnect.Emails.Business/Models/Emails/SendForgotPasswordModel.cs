namespace InstaConnect.Emails.Business.Models.Emails;

public class SendForgotPasswordModel
{
    private const string TITLE = "Forgot password";


    public string UserId { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public string Title => TITLE;
}
