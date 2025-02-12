using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

public record AddEmailConfirmationTokenCommand(string Email) : ICommand;
