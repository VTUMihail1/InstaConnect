using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.SendAccountPasswordReset;

public class SendAccountPasswordResetCommand : ICommand
{
    public string Email { get; set; } = string.Empty;
}
