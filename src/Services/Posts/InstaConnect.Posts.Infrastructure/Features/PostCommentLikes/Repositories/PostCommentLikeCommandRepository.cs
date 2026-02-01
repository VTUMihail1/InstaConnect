using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Repositories;

internal class PostCommentLikeCommandRepository : IPostCommentLikeCommandRepository
{
    private readonly IPostsContext _context;
    private readonly IPostCommentLikeIncluderFactory _commentLikeIncluderFactory;

    public PostCommentLikeCommandRepository(
        IPostsContext context,
        IPostCommentLikeIncluderFactory commentLikeIncluderFactory)
    {
        _context = context;
        _commentLikeIncluderFactory = commentLikeIncluderFactory;
    }

    public async Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostCommentLikes
            .Aggregate()
            .Includes(_commentLikeIncluderFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostCommentLikes
            .Aggregate()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken)
    {
        await _context
            .PostCommentLikes
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken)
    {
        await _context
            .PostCommentLikes
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken)
    {
        await _context
            .PostCommentLikes
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
