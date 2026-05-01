namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowCollectionQueryResponse(
	UserQueryResponse? Follower,
	UserQueryResponse? Following,
	ICollection<FollowQueryResponse> Follows,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionQueryResponse;
