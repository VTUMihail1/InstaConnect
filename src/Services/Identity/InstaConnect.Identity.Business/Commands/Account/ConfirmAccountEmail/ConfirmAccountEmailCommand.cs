using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.ConfirmAccountEmail;

public record ConfirmAccountEmailCommand(string UserId, string Token) : ICommand;
