namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

public record DeletePostCommandRequest(string Id, string CurrentUserId) : ICommandRequest;
