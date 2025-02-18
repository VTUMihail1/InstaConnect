namespace InstaConnect.Posts.Application.Features.Posts.Commands.Delete;

public record DeletePostCommand(string Id, string CurrentUserId) : ICommand;
