using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;

public record ResendAccountEmailConfirmationCommand(string Email) : ICommand;
