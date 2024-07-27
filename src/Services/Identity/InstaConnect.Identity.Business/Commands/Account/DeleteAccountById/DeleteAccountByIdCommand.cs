using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.DeleteAccountById;

public record DeleteAccountByIdCommand(string Id) : ICommand;
