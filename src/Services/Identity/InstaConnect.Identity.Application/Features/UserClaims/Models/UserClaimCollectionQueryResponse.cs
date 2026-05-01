namespace InstaConnect.Identity.Application.Features.UserClaims.Models;

public record UserClaimCollectionQueryResponse(
	UserQueryResponse? User,
	ICollection<UserClaimQueryResponse> UserClaims,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionQueryResponse;
