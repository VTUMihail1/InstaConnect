namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowingQuery(
    FollowByFollowingFilterQuery Filter,
    FollowByFollowingSortingQuery Sorting,
    FollowPaginationQuery Pagination);
