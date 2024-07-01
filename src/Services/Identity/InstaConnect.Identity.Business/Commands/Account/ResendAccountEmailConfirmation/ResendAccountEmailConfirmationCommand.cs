using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.ResendAccountEmailConfirmation;

public class ResendAccountEmailConfirmationCommand : ICommand
{
    public string Email { get; set; } = string.Empty;
}
