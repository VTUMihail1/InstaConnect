using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeRepository
{
    Task<PostLikeCollection> GetAllAsync(
        PostLikeFilterQuery filter,
        CommonSortingQuery<PostLikeSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<PostLikeIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        CommonIncludeQuery<PostLikeIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken);

    Task AddAsync(PostLike entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken);

    Task DeleteAsync(PostLike entity, CancellationToken cancellationToken);
}
