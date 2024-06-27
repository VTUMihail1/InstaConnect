using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.RegisterAccount;

public class RegisterAccountCommand : ICommand
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
