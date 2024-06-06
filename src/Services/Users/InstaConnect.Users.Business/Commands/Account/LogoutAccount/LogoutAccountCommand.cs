using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.Account.LogoutAccount;

public class LogoutAccountCommand : ICommand
{
    public string Value { get; set; }
}
