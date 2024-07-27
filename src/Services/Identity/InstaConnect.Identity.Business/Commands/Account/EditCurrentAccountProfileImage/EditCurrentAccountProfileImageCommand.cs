using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Business.Commands.Account.EditCurrentAccount;

public record EditCurrentAccountProfileImageCommand(string CurrentUserId, IFormFile ProfileImage) : ICommand<AccountCommandViewModel>;
