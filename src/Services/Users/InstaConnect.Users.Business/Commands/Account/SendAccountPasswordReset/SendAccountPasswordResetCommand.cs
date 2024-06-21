using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Users.Business.Commands.Account.SendAccountPasswordReset;

public class SendAccountPasswordResetCommand : ICommand
{
    public string Email { get; set; }
}
