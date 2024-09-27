using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Business.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;

public record EditCurrentUserCommand(string CurrentUserId, string FirstName, string LastName, string UserName, IFormFile? ProfileImage) : ICommand<UserCommandViewModel>;
