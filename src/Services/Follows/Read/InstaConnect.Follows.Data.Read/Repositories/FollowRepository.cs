using InstaConnect.Follows.Data.Read;
using InstaConnect.Follows.Data.Read.Abstractions;
using InstaConnect.Follows.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Read.Repositories;

public class FollowRepository : BaseRepository<Follow>, IFollowRepository
{
    private readonly FollowsContext _followsContext;

    public FollowRepository(FollowsContext followsContext) : base(followsContext)
    {
        _followsContext = followsContext;
    }

    public virtual async Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken)
    {
        var follow =
        await IncludeProperties(
            _followsContext.Follows)
            .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);

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
