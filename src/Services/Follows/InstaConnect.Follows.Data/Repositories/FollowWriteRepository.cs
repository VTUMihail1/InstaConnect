using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Repositories;

public class FollowWriteRepository : BaseWriteRepository<Follow>, IFollowWriteRepository
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
}
