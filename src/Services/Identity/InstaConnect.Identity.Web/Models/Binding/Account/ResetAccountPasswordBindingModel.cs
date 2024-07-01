namespace InstaConnect.Identity.Web.Models.Binding.Account;

public class ResetAccountPasswordBindingModel
{
    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;
}
