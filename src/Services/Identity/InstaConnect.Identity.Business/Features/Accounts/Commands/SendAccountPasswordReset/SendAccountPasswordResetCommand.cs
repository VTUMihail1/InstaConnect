using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;

public record SendAccountPasswordResetCommand(string Email) : ICommand;
