using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.ResetUserPassword;

public record ResetUserPasswordCommand(string UserId, string Token, string Password, string ConfirmPassword) : ICommand;
