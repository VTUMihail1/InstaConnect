using InstaConnect.Common.Domain.Features.Messaging.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsForFollowingQuery(
    FollowsForFollowingFilterQuery Filter,
    FollowsForFollowingSortingQuery Sorting,
    FollowsPaginationQuery Pagination,
    CurrentUserQuery CurrentUser)
    : ISortableQuery<FollowsForFollowingSortingQuery, FollowsForFollowingSortTerm>, IPaginatableQuery<FollowsPaginationQuery>, ICurrentUserableQuery;
