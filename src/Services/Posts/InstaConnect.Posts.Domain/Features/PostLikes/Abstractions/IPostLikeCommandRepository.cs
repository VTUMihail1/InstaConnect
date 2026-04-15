namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeCommandRepository
{
    Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        PostLikeInclude? include,
        CancellationToken cancellationToken);

    Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken);

    Task AddAsync(PostLike entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken);

    Task DeleteAsync(PostLike entity, CancellationToken cancellationToken);
}
