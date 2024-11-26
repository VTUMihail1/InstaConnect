using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.ResendUserEmailConfirmation;

public record ResendUserEmailConfirmationCommand(string Email) : ICommand;
