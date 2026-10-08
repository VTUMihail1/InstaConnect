using InstaConnect.Common.Domain.Features.Requests.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
