namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Bodies;

public class VerifyForgotPasswordTokenBody
{
    public VerifyForgotPasswordTokenBody(
        string password,
        string confirmPassword)
    {
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}
