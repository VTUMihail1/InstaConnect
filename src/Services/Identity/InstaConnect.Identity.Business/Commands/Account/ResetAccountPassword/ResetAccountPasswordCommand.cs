using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.ResetAccountPassword;

public record ResetAccountPasswordCommand(string UserId, string Token, string Password, string ConfirmPassword) : ICommand;
