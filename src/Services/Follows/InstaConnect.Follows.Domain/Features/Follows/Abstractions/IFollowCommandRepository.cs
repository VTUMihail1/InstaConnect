namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowCommandRepository
{
    Task AddAsync(Follow entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken);

    Task DeleteAsync(Follow entity, CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(FollowId id, CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(FollowId id, FollowInclude? include, CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(FollowId id, CancellationToken cancellationToken);
}
