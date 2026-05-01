namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record GetPostCommentLikeByIdQuery(
	PostCommentLikeId Id,
	CurrentUserQuery CurrentUser) : ICurrentUserableQuery;
