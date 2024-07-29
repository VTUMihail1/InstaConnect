using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;

public record LoginAccountCommand(string Email, string Password) : ICommand<AccountTokenCommandViewModel>;
