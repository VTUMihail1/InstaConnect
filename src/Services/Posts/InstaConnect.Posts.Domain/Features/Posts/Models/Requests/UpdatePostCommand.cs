namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record UpdatePostCommand(
	PostId Id,
	UserId UserId,
	string Title,
	string Content);
