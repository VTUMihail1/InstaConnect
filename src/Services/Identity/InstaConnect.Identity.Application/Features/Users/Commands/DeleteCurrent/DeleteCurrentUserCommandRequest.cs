namespace InstaConnect.Users.Application.Features.Users.Commands.Delete;

public record DeleteCurrentUserCommandRequest(string Id) : ICommandRequest;
