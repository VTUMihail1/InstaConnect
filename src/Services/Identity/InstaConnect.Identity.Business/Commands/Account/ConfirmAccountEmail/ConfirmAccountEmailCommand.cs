using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public class ConfirmAccountEmailCommand : ICommand
{
    public string UserId { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;
}
