namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllPostsQuery(
    PostFilterQuery Filter,
    PostSortingQuery Sorting,
    PostPaginationQuery Pagination)
{
    public PostIncludeQuery? Include { get; private set; }

    public GetAllPostsQuery AddInclues(PostIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
