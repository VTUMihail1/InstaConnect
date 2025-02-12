using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

public record AddForgotPasswordTokenCommand(string Email) : ICommand;
