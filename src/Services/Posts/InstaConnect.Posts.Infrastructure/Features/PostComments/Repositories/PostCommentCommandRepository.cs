using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Repositories;

internal class PostCommentCommandRepository : IPostCommentCommandRepository
{
    private readonly IPostsContext _context;
    private readonly IPostCommentIncluderFactory _commentIncluderFactory;

    public PostCommentCommandRepository(
        IPostsContext context,
        IPostCommentIncluderFactory commentIncluderFactory)
    {
        _context = context;
        _commentIncluderFactory = commentIncluderFactory;
    }

    public async Task<PostComment?> GetByIdAsync(
        PostCommentId id,
        PostCommentInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .Aggregate()
            .Includes(_commentIncluderFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PostComment?> GetByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .Aggregate()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(PostComment entity, CancellationToken cancellationToken)
    {
        await _context
            .PostComments
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken)
    {
        await _context
            .PostComments
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(PostComment entity, CancellationToken cancellationToken)
    {
        await _context
            .PostComments
            .UpdateAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteAsync(PostComment entity, CancellationToken cancellationToken)
    {
        await _context
            .PostComments
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
