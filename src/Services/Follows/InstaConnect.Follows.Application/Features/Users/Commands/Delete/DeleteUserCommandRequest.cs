using InstaConnect.Follows.Application.Features.Users.Models;

namespace InstaConnect.Follows.Application.Features.Users.Commands.Delete;

public record DeleteUserCommandRequest(UserIdPayload Id) : ICommandRequest;
