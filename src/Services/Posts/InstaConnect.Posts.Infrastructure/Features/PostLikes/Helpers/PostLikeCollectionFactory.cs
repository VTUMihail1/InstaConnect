using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Helpers;

internal class PostLikeCollectionFactory : IPostLikeCollectionFactory
{
    public PostLikeCollection Create(ICollection<PostLike> postLikes, int totalCount, PostLikePaginationQuery pagination)
    {
        var hasNextPage = pagination.Page * pagination.PageSize < totalCount;
        var hasPreviousPage = pagination.Page > 1;

        return new PostLikeCollection(
            postLikes,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
