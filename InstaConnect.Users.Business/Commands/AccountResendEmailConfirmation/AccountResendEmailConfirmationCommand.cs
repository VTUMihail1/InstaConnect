using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.AccountResendEmailConfirmation
{
    public class AccountResendEmailConfirmationCommand : ICommand
    {
        public string Email { get; set; }
    }
}
