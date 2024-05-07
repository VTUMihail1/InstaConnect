namespace InstaConnect.Users.Web.Models.Requests.Account;

public class PasswordBodyRequestModel
{
    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}
