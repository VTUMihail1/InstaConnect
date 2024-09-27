namespace InstaConnect.Identity.Web.Features.Users.Models.Bindings;

public class ResetUserPasswordBindingModel
{
    public ResetUserPasswordBindingModel(
        string password,
        string confirmPassword)
    {
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}
