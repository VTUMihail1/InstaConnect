using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.ResendUserEmailConfirmation;

public record AddEmailConfirmationTokenCommand(string Email) : ICommand;
