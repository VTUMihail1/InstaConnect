using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowerQuery(
    FollowByFollowerFilterQuery Filter,
    CommonSortingQuery<FollowByFollowerSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<FollowByFollowerSortProperty>, IPaginatableQuery, IIncludableQuery<FollowIncludeProperty>
{
    public CommonIncludeQuery<FollowIncludeProperty>? Include { get; private set; }

    public GetAllFollowsByFollowerQuery AddInclude(CommonIncludeQuery<FollowIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
