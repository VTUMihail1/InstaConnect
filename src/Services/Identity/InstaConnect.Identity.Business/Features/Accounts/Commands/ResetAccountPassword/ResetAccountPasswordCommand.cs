using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;

public record ResetAccountPasswordCommand(string UserId, string Token, string Password, string ConfirmPassword) : ICommand;
