namespace InstaConnect.Identity.Web.Features.Accounts.Models.Bindings;

public class LoginAccountBindingModel
{
    public LoginAccountBindingModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }

    public string Password { get; set; }
}
