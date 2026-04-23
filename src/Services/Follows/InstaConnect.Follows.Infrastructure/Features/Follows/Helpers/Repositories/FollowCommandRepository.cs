using InstaConnect.Follows.Infrastructure.Features.Common.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Repositories;

internal class FollowCommandRepository : IFollowCommandRepository
{
    private readonly IFollowsContext _context;
    private readonly IFollowIncluderFactory _includerFactory;

    public FollowCommandRepository(
        IFollowsContext context,
        IFollowIncluderFactory includerFactory)
    {
        _context = context;
        _includerFactory = includerFactory;
    }

    public async Task<Follow?> GetByIdAsync(
        FollowId id,
        FollowInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Follow?> GetByIdAsync(
        FollowId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        FollowId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(Follow entity, CancellationToken cancellationToken)
    {
        await _context
            .Follows
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken)
    {
        await _context
            .Follows
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(Follow entity, CancellationToken cancellationToken)
    {
        await _context
            .Follows
            .UpdateAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteAsync(Follow entity, CancellationToken cancellationToken)
    {
        await _context
            .Follows
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
