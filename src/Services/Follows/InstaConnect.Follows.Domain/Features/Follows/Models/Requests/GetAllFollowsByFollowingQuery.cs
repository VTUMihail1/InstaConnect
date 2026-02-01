namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowingQuery(
    FollowByFollowingFilterQuery Filter,
    FollowByFollowingSortingQuery Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<FollowByFollowingSortProperty>, IPaginatableQuery, IIncludableQuery<FollowIncludeProperty>
{
    public FollowInclude Include { get; private set; }

    public GetAllFollowsByFollowingQuery AddInclude(CommonInclude<FollowIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
