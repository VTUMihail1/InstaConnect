using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteAccountById;

public record DeleteAccountByIdCommand(string Id) : ICommand;
