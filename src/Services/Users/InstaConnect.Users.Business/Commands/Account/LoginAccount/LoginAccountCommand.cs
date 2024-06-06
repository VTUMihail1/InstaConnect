using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Commands.Account.LoginAccount;

public class LoginAccountCommand : ICommand<AccountViewDTO>
{
    public string Email { get; set; }

    public string Password { get; set; }
}
