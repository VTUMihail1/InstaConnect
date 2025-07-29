namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostCommand(string UserId, string Title, string Content);
