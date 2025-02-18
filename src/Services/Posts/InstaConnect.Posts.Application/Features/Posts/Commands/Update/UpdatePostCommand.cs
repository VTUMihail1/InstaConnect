namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public record UpdatePostCommand(string Id, string CurrentUserId, string Title, string Content) : ICommand<PostCommandViewModel>;
