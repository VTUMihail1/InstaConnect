using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.ResendUserEmailConfirmation;

public record ResendUserEmailConfirmationCommand(string Email) : ICommand;
