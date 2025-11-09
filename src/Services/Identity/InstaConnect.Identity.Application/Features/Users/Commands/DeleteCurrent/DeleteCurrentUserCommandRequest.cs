namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;

public record DeleteCurrentUserCommandRequest(string Id) : ICommandRequest;
