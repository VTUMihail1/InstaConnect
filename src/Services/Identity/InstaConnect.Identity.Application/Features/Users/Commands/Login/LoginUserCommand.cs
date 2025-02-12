using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Login;

public record LoginUserCommand(string Email, string Password) : ICommand<UserTokenCommandViewModel>;
