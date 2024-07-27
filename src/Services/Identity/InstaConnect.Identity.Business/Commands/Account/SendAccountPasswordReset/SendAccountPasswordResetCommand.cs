using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.SendAccountPasswordReset;

public record SendAccountPasswordResetCommand(string Email) : ICommand;
