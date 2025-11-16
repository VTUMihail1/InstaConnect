namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeRepository
{
    Task<PostLikeCollection> GetAllAsync(
        PostLikeFilterQuery filter,
        PostLikeSortingQuery sorting,
        PostLikePaginationQuery pagination,
        PostLikeIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        PostLikeIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken);

    Task AddAsync(PostLike entity, CancellationToken cancellationToken);

    Task DeleteAsync(PostLike entity, CancellationToken cancellationToken);
}
