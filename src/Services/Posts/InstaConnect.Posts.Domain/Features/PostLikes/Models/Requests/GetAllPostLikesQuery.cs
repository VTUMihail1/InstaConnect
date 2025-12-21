using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record GetAllPostLikesQuery(
    PostLikeFilterQuery Filter,
    CommonSortingQuery<PostLikeSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<PostLikeSortProperty>, IPaginatableQuery, IIncludableQuery<PostLikeIncludeProperty>
{
    public CommonIncludeQuery<PostLikeIncludeProperty>? Include { get; private set; }

    public GetAllPostLikesQuery AddInclude(CommonIncludeQuery<PostLikeIncludeProperty> include)
    {
        Include = include;

        return this;
    }
}
