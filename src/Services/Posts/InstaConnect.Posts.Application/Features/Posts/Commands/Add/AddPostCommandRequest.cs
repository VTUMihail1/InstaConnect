namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostCommandRequest(string CurrentUserId, string Title, string Content) : ICommandRequest<AddPostCommandResponse>;
