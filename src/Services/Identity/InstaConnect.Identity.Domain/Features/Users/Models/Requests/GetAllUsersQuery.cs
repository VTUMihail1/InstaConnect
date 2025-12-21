using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record GetAllUsersQuery(
    UserFilterQuery Filter,
    CommonSortingQuery<UserSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<UserSortProperty>, IPaginatableQuery, IIncludableQuery<UserIncludeProperty>
{
    public CommonIncludeQuery<UserIncludeProperty>? Include { get; private set; }

    public GetAllUsersQuery AddInclude(CommonIncludeQuery<UserIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
