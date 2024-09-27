using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.DeleteUserById;

public record DeleteUserByIdCommand(string Id) : ICommand;
