namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostRequest(string CurrentUserId, string Title, string Content);
