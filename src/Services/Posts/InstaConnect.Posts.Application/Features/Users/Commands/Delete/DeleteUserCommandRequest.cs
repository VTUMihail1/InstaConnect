using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.Users.Commands.Delete;

public record DeleteUserCommandRequest(UserIdPayload Id) : ICommandRequest;
