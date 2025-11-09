namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetAllPostCommentsQuery(
    PostCommentFilterQuery Filter,
    PostCommentSortingQuery Sorting,
    PostCommentPaginationQuery Pagination)
{
    public PostCommentIncludeQuery? Include { get; private set; }

    public GetAllPostCommentsQuery AddInclude(PostCommentIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
