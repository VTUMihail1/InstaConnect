using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Delete;

public record DeleteUserCommand(string Id) : ICommand;
