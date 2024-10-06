namespace InstaConnect.Identity.Web.Features.Users.Models.Bindings;

public class LoginUserBindingModel
{
    public LoginUserBindingModel(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }

    public string Password { get; set; }
}
