namespace InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;

public class ResetAccountPasswordBindingModel
{
    public ResetAccountPasswordBindingModel(
        string password,
        string confirmPassword)
    {
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}
