namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostCommand(string CurrentUserId, string Title, string Content) : ICommand<PostCommandViewModel>;
