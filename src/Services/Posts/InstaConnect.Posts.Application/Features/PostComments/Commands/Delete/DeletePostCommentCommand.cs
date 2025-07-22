namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

public record DeletePostCommentCommand(string Id, string PostId, string CurrentUserId) : ICommandRequest;
