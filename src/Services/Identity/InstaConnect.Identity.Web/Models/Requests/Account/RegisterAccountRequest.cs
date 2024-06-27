namespace InstaConnect.Identity.Web.Models.Requests.Account;

public class RegisterAccountRequest
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
