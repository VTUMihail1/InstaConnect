using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.AccountSendPasswordReset
{
    public class AccountSendPasswordResetCommand : ICommand
    {
        public string Email { get; set; }
    }
}
