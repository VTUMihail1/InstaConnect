using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowingQuery(
    FollowByFollowingFilterQuery Filter,
    CommonSortingQuery<FollowByFollowingSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<FollowByFollowingSortProperty>, IPaginatableQuery, IIncludableQuery<FollowIncludeProperty>
{
    public CommonIncludeQuery<FollowIncludeProperty>? Include { get; private set; }

    public GetAllFollowsByFollowingQuery AddInclude(CommonIncludeQuery<FollowIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
