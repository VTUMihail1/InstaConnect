namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers;

internal class PostCommentCollectionFactory : IPostCommentCollectionFactory
{
    private readonly IPaginator _paginator;

    public PostCommentCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public PostCommentCollection Create(ICollection<PostComment> postComments, int totalCount, PostCommentPaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new PostCommentCollection(
            postComments,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
