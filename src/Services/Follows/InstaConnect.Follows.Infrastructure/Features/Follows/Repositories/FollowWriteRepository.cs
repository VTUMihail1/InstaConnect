using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Repositories;

internal class FollowWriteRepository : IFollowWriteRepository
{
    private readonly FollowsContext _followsContext;

    public FollowWriteRepository(FollowsContext followsContext)
    {
        _followsContext = followsContext;
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

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        var any = await _followsContext
            .Follows
            .AnyAsync(cancellationToken);

        return any;
    }

    public void Add(Follow follow)
    {
        _followsContext
            .Follows
            .Add(follow);
    }

    public void Delete(Follow follow)
    {
        _followsContext
            .Follows
            .Remove(follow);
    }
}
