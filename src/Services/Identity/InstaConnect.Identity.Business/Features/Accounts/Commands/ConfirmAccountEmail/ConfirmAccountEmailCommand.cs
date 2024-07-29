using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ConfirmAccountEmail;

public record ConfirmAccountEmailCommand(string UserId, string Token) : ICommand;
