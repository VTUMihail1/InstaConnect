using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Repositories;

internal class FollowReadRepository : IFollowReadRepository
{
    private readonly FollowsContext _followsContext;

    public FollowReadRepository(FollowsContext followsContext)
    {
        _followsContext = followsContext;
    }

    public async Task<PaginationList<Follow>> GetAllAsync(FollowCollectionReadQuery query, CancellationToken cancellationToken)
    {
        var follows = await _followsContext
            .Follows
            .Include(f => f.Follower)
            .Include(f => f.Following)
            .AsSplitQuery()
            .Where(f => (string.IsNullOrEmpty(query.FollowerId) || f.FollowerId == query.FollowerId) &&
                        (string.IsNullOrEmpty(query.FollowerName) || f.Follower!.UserName.StartsWith(query.FollowerName)) &&
                        (string.IsNullOrEmpty(query.FollowingId) || f.FollowingId == query.FollowingId) &&
                        (string.IsNullOrEmpty(query.FollowingName) || f.Following!.UserName.StartsWith(query.FollowingName)))
            .OrderEntities(query.SortOrder, query.SortPropertyName)
            .ToPagedListAsync(query.Page, query.PageSize, cancellationToken);

        return follows;
    }

    public async Task<Follow?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var follow = await _followsContext
            .Follows
            .Include(f => f.Follower)
            .Include(f => f.Following)
            .AsSplitQuery()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return follow;
    }

    public async Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken)
    {
        var follow = await _followsContext
            .Follows
            .Include(f => f.Follower)
            .Include(f => f.Following)
            .AsSplitQuery()
            .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId, cancellationToken);

        return follow;
    }
}
