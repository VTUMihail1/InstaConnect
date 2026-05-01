namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record UpdatePostCommentCommand(
	PostCommentId Id,
	UserId UserId,
	string Content);
