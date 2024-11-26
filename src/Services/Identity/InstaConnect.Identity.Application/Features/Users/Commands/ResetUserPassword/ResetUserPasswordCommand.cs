using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.ResetUserPassword;

public record ResetUserPasswordCommand(string UserId, string Token, string Password, string ConfirmPassword) : ICommand;
