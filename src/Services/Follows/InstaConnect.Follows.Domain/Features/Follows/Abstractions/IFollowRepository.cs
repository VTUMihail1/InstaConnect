namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowRepository
{
    Task<FollowCollection> GetAllByFollowerAsync(
        FollowByFollowerFilterQuery filter,
        FollowByFollowerSortingQuery sorting,
        FollowPaginationQuery pagination,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<FollowCollection> GetAllByFollowingAsync(
        FollowByFollowingFilterQuery filter,
        FollowByFollowingSortingQuery sorting,
        FollowPaginationQuery pagination,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(
        string followerId,
        string followingId,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(
        string followerId,
        string followingId,
        CancellationToken cancellationToken);

    Task AddAsync(Follow entity, CancellationToken cancellationToken);

    Task UpdateAsync(Follow entity, CancellationToken cancellationToken);

    Task DeleteAsync(Follow entity, CancellationToken cancellationToken);
}
