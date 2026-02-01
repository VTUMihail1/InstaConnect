namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowRepository
{
    Task<FollowCollection> GetAllByFollowerAsync(
        FollowByFollowerFilterQuery filter,
        FollowByFollowerSortingQuery sorting,
        CommonPaginationQuery pagination,
        FollowInclude include,
        CancellationToken cancellationToken);

    Task<FollowCollection> GetAllByFollowingAsync(
        FollowByFollowingFilterQuery filter,
        FollowByFollowingSortingQuery sorting,
        CommonPaginationQuery pagination,
        FollowInclude include,
        CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(
        FollowId id,
        FollowInclude include,
        CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(
        FollowId id,
        CancellationToken cancellationToken);

    Task AddAsync(Follow entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken);

    Task DeleteAsync(Follow entity, CancellationToken cancellationToken);
}
