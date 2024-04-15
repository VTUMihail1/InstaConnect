using InstaConnect.Shared.Messaging;

namespace InstaConnect.Users.Business.Commands.Account.AccountLogout
{
    public class AccountLogoutCommand : ICommand
    {
        public string Value { get; set; }
    }
}
