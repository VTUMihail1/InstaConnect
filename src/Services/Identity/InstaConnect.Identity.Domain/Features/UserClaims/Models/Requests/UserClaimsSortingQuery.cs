using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimsSortingQuery(
	CommonSortOrder Order,
	UserClaimsSortTerm Term) : ISortingQuery<UserClaimsSortTerm>;
