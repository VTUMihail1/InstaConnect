using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Helpers;

internal class PostLikeCollectionFactory : IPostLikeCollectionFactory
{
    private readonly IPaginator _paginator;

    public PostLikeCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public PostLikeCollection Create(ICollection<PostLike> postLikes, int totalCount, PostLikePaginationQuery pagination)
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
