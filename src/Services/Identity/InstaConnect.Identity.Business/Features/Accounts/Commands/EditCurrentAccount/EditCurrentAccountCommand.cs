using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Shared.Business.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;

public record EditCurrentAccountCommand(string CurrentUserId, string FirstName, string LastName, string UserName, IFormFile? ProfileImage) : ICommand<AccountCommandViewModel>;
