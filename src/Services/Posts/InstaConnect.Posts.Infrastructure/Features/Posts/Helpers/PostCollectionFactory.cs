using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers;

internal class PostCollectionFactory : IPostCollectionFactory
{
    private readonly IPaginator _paginator;

    public PostCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public PostCollection Create(ICollection<Post> posts, long totalCount, PostPaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new PostCollection(
            posts,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
