namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

public record UpdatePostCommentCommandRequest(
	string Id,
	string CommentId,
	string UserId,
	string Content) : ICommandRequest<UpdatePostCommentCommandResponse>;
