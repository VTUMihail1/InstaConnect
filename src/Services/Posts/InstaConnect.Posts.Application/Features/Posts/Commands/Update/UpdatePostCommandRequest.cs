namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public record UpdatePostCommandRequest(string Id, string CurrentUserId, string Title, string Content) : ICommandRequest<UpdatePostCommandResponse>;
