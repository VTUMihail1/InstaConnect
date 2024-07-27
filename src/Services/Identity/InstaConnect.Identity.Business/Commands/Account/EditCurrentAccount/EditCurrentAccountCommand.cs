using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;

public record EditCurrentAccountCommand(string CurrentUserId, string FirstName, string LastName, string UserName) : ICommand<AccountCommandViewModel>;
