namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeCollectionQueryResponse(
	PostQueryResponse? Post,
	UserQueryResponse? User,
	ICollection<PostLikeQueryResponse> PostLikes,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionQueryResponse;
