namespace InstaConnect.Identity.Web.Models.Binding.Account;

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
