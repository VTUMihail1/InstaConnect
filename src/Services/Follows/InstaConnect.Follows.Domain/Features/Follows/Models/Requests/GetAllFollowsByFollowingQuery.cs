namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowingQuery(
    FollowByFollowingFilterQuery Filter,
    FollowByFollowingSortingQuery Sorting,
    FollowPaginationQuery Pagination)
{
    public FollowIncludeQuery? Include { get; private set; }

    public GetAllFollowsByFollowingQuery AddInclude(FollowIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
