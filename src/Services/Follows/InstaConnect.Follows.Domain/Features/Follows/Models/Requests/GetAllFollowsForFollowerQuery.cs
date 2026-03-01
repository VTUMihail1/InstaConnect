namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsForFollowerQuery(
    FollowsForFollowerFilterQuery Filter,
    FollowsForFollowerSortingQuery Sorting,
    FollowsPaginationQuery Pagination,
    CurrentUserQuery CurrentUser)
    : ISortableQuery<FollowsForFollowerSortingQuery, FollowsForFollowerSortTerm>, IPaginatableQuery<FollowsPaginationQuery>, ICurrentUserableQuery;
