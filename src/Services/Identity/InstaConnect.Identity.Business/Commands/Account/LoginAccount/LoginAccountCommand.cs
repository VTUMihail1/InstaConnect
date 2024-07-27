using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Commands.Account.LoginAccount;

public record LoginAccountCommand(string Email, string Password) : ICommand<AccountTokenCommandViewModel>;
