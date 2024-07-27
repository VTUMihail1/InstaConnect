using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.ResendAccountEmailConfirmation;

public record ResendAccountEmailConfirmationCommand(string Email) : ICommand;
