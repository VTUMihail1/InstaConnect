namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeCollectionQueryResponse(
	PostCommentQueryResponse? PostComment,
	UserQueryResponse? User,
	ICollection<PostCommentLikeQueryResponse> PostCommentLikes,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionQueryResponse;
