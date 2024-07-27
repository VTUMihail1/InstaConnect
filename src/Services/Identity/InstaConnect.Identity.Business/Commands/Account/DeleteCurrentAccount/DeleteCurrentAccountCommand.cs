using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.DeleteCurrentAccount;

public record DeleteCurrentAccountCommand(string CurrentUserId) : ICommand;
