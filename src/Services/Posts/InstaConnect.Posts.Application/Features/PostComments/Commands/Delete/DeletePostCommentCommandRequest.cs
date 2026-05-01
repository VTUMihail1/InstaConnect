namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

public record DeletePostCommentCommandRequest(
	string Id,
	string CommentId,
	string UserId) : ICommandRequest;
