using InstaConnect.Common.Domain.Features.Requests.Abstractions;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;

public record UserClaimCollectionResponse(
	UserResponse? User,
	ICollection<UserClaimResponse> UserClaims,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionResponse;
