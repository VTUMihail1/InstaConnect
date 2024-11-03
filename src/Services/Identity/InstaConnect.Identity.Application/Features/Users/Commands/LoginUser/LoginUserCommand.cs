using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : ICommand<UserTokenCommandViewModel>;
