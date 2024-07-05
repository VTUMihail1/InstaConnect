namespace InstaConnect.Identity.Web.Models.Binding.Account;

public class RegisterAccountBindingModel
{
    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public IFormFile? ProfileImage { get; set; }
}
