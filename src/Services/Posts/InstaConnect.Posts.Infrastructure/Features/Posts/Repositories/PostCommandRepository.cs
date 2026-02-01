using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostCommandRepository : IPostCommandRepository
{
    private readonly IPostsContext _context;
    private readonly IPostIncluderFactory _includerFactory;

    public PostCommandRepository(
        IPostsContext context,
        IPostIncluderFactory includerFactory)
    {
        _context = context;
        _includerFactory = includerFactory;
    }

    public async Task<Post?> GetByIdAsync(
        PostId id,
        PostInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Posts
            .Aggregate()
            .Includes(_includerFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Post?> GetByIdAsync(
        PostId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Posts
            .Aggregate()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(Post entity, CancellationToken cancellationToken)
    {
        await _context
            .Posts
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<Post> entities, CancellationToken cancellationToken)
    {
        await _context
            .Posts
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(Post entity, CancellationToken cancellationToken)
    {
        await _context
            .Posts
            .UpdateAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteAsync(Post entity, CancellationToken cancellationToken)
    {
        await _context
            .Posts
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
