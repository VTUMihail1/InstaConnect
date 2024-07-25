using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Repositories;

internal class FollowWriteRepository : BaseWriteRepository<Follow>, IFollowWriteRepository
{
    private readonly FollowsContext _followsContext;

    public FollowWriteRepository(FollowsContext followsContext) : base(followsContext)
    {
        _followsContext = followsContext;
    }

    public virtual async Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken)
    {
        var follow =
        await IncludeProperties(
            _followsContext.Follows)
            .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId, cancellationToken);

        return follow;
    }

    protected override IQueryable<Follow> IncludeProperties(IQueryable<Follow> queryable)
    {
        return queryable
            .Include(f => f.Follower)
            .Include(f => f.Following)
            .AsSplitQuery();
    }
}
