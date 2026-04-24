using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class PostLikeCommandRepository : IPostLikeCommandRepository
{
    private readonly IPostsContext _context;
    private readonly IPostLikeIncluderFactory _likeIncluderFactory;

    public PostLikeCommandRepository(
        IPostsContext context,
        IPostLikeIncluderFactory likeIncluderFactory)
    {
        _context = context;
        _likeIncluderFactory = likeIncluderFactory;
    }

    public async Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        PostLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .Aggregate()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(PostLike entity, CancellationToken cancellationToken)
    {
        await _context
            .PostLikes
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken)
    {
        await _context
            .PostLikes
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(PostLike entity, CancellationToken cancellationToken)
    {
        await _context
            .PostLikes
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
