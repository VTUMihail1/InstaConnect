using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteUserById;

public record DeleteUserCommand(string Id) : ICommand;
