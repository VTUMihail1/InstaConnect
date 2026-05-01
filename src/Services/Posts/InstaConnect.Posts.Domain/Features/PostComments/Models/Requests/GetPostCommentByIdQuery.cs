namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetPostCommentByIdQuery(
	PostCommentId Id,
	CurrentUserQuery CurrentUser) : ICurrentUserableQuery;
