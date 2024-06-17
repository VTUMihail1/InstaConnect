namespace InstaConnect.Users.Web.Models.Requests.Account;

public class PasswordBodyRequest
{
    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}
