using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;

public record EditCurrentAccountCommand(string CurrentUserId, string FirstName, string LastName, string UserName) : ICommand<AccountCommandViewModel>;
