using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers;

internal class PostCommentLikeCollectionFactory : IPostCommentLikeCollectionFactory
{
    private readonly IPaginator _paginator;

    public PostCommentLikeCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public PostCommentLikeCollection Create(ICollection<PostCommentLike> entities, int totalCount, CommonPaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new PostCommentLikeCollection(
            entities,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
