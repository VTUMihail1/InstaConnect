using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimsSortingQuery(
	CommonSortOrder Order,
	UserClaimsSortTerm Term) : ISortingQuery<UserClaimsSortTerm>;
