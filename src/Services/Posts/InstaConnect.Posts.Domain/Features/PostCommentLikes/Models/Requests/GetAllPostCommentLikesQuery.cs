using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesQuery(
    PostCommentLikeFilterQuery Filter,
    CommonSortingQuery<PostCommentLikeSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<PostCommentLikeSortProperty>, IPaginatableQuery, IIncludableQuery<PostCommentLikeIncludeProperty>
{
    public CommonIncludeQuery<PostCommentLikeIncludeProperty>? Include { get; private set; }

    public GetAllPostCommentLikesQuery AddInclude(CommonIncludeQuery<PostCommentLikeIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
