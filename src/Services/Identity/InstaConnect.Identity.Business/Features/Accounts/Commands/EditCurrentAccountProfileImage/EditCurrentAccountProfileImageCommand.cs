using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Shared.Business.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccountProfileImage;

public record EditCurrentAccountProfileImageCommand(string CurrentUserId, IFormFile ProfileImage) : ICommand<AccountCommandViewModel>;
