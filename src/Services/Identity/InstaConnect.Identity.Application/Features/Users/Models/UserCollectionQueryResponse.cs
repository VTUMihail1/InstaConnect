namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserCollectionQueryResponse(
	ICollection<UserQueryResponse> Users,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionQueryResponse;
