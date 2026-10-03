using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UsersSortingQuery(
	CommonSortOrder Order,
	UsersSortTerm Term) : ISortingQuery<UsersSortTerm>;
