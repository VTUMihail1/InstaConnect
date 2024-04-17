using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.AccountLogout
{
    public class AccountLogoutCommand : ICommand
    {
        public string Value { get; set; }
    }
}
