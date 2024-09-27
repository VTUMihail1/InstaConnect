using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.SendUserPasswordReset;

public record SendUserPasswordResetCommand(string Email) : ICommand;
