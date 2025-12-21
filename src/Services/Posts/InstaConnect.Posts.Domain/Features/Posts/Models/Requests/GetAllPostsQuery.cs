using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllPostsQuery(
    PostFilterQuery Filter,
    CommonSortingQuery<PostSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<PostSortProperty>, IPaginatableQuery, IIncludableQuery<PostIncludeProperty>
{
    public CommonIncludeQuery<PostIncludeProperty>? Include { get; private set; }

    public GetAllPostsQuery AddInclude(CommonIncludeQuery<PostIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
