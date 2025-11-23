namespace InstaConnect.Chats.Application.Features.Users.Commands.Delete;

public record DeleteUserCommandRequest(UserIdPayload Id) : ICommandRequest;
