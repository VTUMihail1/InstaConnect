using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeRepository
{
    Task<PostCommentLikeCollection> GetAllAsync(
        PostCommentLikeFilterQuery filter,
        CommonSortingQuery<PostCommentLikeSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<PostCommentLikeIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        CommonIncludeQuery<PostCommentLikeIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken);

    Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken);

    Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken);
}
