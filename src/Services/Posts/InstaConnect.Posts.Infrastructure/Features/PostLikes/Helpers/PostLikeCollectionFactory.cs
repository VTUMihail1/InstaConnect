using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers;

internal class PostLikeCollectionFactory : IPostLikeCollectionFactory
{
    private readonly IPaginator _paginator;

    public PostLikeCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public PostLikeCollection Create(ICollection<PostLike> postLikes, int totalCount, CommonPaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new PostLikeCollection(
            postLikes,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
