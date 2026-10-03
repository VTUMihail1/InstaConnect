using InstaConnect.Common.Domain.Features.Requests.Abstractions;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimsPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
