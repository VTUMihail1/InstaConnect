namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowerQuery(
    FollowByFollowerFilterQuery Filter,
    FollowByFollowerSortingQuery Sorting,
    FollowPaginationQuery Pagination);
