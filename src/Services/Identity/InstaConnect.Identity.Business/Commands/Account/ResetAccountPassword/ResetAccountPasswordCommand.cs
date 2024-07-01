using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.ResetAccountPassword;

public class ResetAccountPasswordCommand : ICommand
{
    public string UserId { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;
}
