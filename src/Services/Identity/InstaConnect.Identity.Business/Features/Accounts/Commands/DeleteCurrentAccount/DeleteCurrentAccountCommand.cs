using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteCurrentAccount;

public record DeleteCurrentAccountCommand(string CurrentUserId) : ICommand;
