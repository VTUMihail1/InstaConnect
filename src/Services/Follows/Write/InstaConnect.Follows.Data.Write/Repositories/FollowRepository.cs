using InstaConnect.Follows.Data.Write.Abstractions;
using InstaConnect.Follows.Data.Write.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Write.Repositories;

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
}
