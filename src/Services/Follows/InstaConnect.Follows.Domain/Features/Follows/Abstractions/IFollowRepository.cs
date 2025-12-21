using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowRepository
{
    Task<FollowCollection> GetAllByFollowerAsync(
        FollowByFollowerFilterQuery filter,
        CommonSortingQuery<FollowByFollowerSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<FollowIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<FollowCollection> GetAllByFollowingAsync(
        FollowByFollowingFilterQuery filter,
        CommonSortingQuery<FollowByFollowingSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<FollowIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(
        FollowId id,
        CommonIncludeQuery<FollowIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<Follow?> GetByIdAsync(
        FollowId id,
        CancellationToken cancellationToken);

    Task AddAsync(Follow entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken);

    Task DeleteAsync(Follow entity, CancellationToken cancellationToken);
}
