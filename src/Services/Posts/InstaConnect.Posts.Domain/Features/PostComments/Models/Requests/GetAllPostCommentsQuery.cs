using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetAllPostCommentsQuery(
    PostCommentFilterQuery Filter,
    CommonSortingQuery<PostCommentSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<PostCommentSortProperty>, IPaginatableQuery, IIncludableQuery<PostCommentIncludeProperty>
{
    public CommonIncludeQuery<PostCommentIncludeProperty>? Include { get; private set; }

    public GetAllPostCommentsQuery AddInclude(CommonIncludeQuery<PostCommentIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
