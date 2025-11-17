namespace InstaConnect.Identity.Application.Features.Users.Commands.Delete;

public record DeleteUserCommandRequest(UserIdPayload Id) : ICommandRequest;
