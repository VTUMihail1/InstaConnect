using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Repositories;

internal class PostLikeWriteRepository : IPostLikeWriteRepository
{
    private readonly PostsContext _postsContext;

    public PostLikeWriteRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public virtual async Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken)
    {
        var postLike = await _postsContext
            .PostLikes
            .FirstOrDefaultAsync(pl => pl.UserId == userId && pl.PostId == postId, cancellationToken);

        return postLike;
    }

    public async Task<PostLike?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var postLike = await _postsContext
            .PostLikes
            .Include(f => f.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return postLike;
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        var any = await _postsContext
            .PostLikes
            .AnyAsync(cancellationToken);

        return any;
    }

    public void Add(PostLike postLike)
    {
        _postsContext
            .PostLikes
            .Add(postLike);
    }

    public void Delete(PostLike postLike)
    {
        _postsContext
            .PostLikes
            .Remove(postLike);
    }
}
