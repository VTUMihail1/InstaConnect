namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowerQuery(
    FollowByFollowerFilterQuery Filter,
    FollowByFollowerSortingQuery Sorting,
    FollowPaginationQuery Pagination)
{
    public FollowIncludeQuery? Include { get; private set; }

    public GetAllFollowsByFollowerQuery AddInclude(FollowIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
