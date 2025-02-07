using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.SendUserPasswordReset;

public record AddForgotPasswordTokenCommand(string Email) : ICommand;
