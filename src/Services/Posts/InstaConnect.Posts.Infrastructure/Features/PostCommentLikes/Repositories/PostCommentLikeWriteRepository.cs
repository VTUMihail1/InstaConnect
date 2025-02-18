namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Repositories;

internal class PostCommentLikeWriteRepository : IPostCommentLikeWriteRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentLikeWriteRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public virtual async Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken)
    {
        var postCommentLike = await _postsContext
            .PostCommentLikes
            .Include(f => f.User)
            .FirstOrDefaultAsync(pl => pl.UserId == userId && pl.PostCommentId == postCommentId, cancellationToken);

        return postCommentLike;
    }

    public async Task<PostCommentLike?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var postCommentLike = await _postsContext
            .PostCommentLikes
            .Include(f => f.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return postCommentLike;
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        var any = await _postsContext
            .PostCommentLikes
            .AnyAsync(cancellationToken);

        return any;
    }

    public void Add(PostCommentLike postCommentLike)
    {
        _postsContext
            .PostCommentLikes
            .Add(postCommentLike);
    }

    public void Delete(PostCommentLike postCommentLike)
    {
        _postsContext
            .PostCommentLikes
            .Remove(postCommentLike);
    }
}
