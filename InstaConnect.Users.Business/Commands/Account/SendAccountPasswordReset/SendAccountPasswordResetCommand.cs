using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Users.Business.Commands.Account.SendAccountPasswordReset;

public class SendAccountPasswordResetCommand : ICommand
{
    public string Email { get; set; }
}
