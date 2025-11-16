using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

public record DeletePostCommandRequest(PostIdPayload Id, UserIdPayload UserId) : ICommandRequest;
