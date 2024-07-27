namespace InstaConnect.Identity.Web.Models.Binding.Account;

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
