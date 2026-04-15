namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostCommandRepository
{
    Task AddAsync(Post entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<Post> entities, CancellationToken cancellationToken);

    Task DeleteAsync(Post entity, CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(PostId id, CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(PostId id, PostInclude? include, CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(PostId id, CancellationToken cancellationToken);

    Task UpdateAsync(Post entity, CancellationToken cancellationToken);
}
