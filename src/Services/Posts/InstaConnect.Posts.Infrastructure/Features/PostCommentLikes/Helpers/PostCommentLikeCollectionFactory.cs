using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Helpers;

internal class PostCommentLikeCollectionFactory : IPostCommentLikeCollectionFactory
{
    private readonly IPaginator _paginator;

    public PostCommentLikeCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public PostCommentLikeCollection Create(ICollection<PostCommentLike> postCommentLikes, int totalCount, PostCommentLikePaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new PostCommentLikeCollection(
            postCommentLikes,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
