namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowerQuery(
    FollowByFollowerFilterQuery Filter,
    FollowByFollowerSortingQuery Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<FollowByFollowerSortProperty>, IPaginatableQuery, IIncludableQuery<FollowIncludeProperty>
{
    public FollowInclude Include { get; private set; }

    public GetAllFollowsByFollowerQuery AddInclude(CommonInclude<FollowIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
