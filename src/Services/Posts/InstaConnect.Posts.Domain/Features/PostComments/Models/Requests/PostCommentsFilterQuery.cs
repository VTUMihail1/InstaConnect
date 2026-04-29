namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentsFilterQuery(
	PostId Id,
	Name UserName);
