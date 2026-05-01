namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostCommandRequest(string UserId, string Title, string Content) : ICommandRequest<AddPostCommandResponse>;
