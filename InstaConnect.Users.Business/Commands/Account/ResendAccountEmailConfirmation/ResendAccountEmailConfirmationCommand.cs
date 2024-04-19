using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.Account.ResendAccountEmailConfirmation
{
    public class ResendAccountEmailConfirmationCommand : ICommand
    {
        public string Email { get; set; }
    }
}
