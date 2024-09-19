using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Features.PostLikes.Repositories;

internal class PostLikeReadRepository : BaseReadRepository<PostLike>, IPostLikeReadRepository
{
    private readonly PostsContext _postsContext;

    public PostLikeReadRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }

    public virtual async Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken)
    {
        var postLike =
        await IncludeProperties(
            _postsContext.PostLikes)
            .FirstOrDefaultAsync(pl => pl.UserId == userId && pl.PostId == postId, cancellationToken);

        return postLike;
    }

    protected override IQueryable<PostLike> IncludeProperties(IQueryable<PostLike> queryable)
    {
        return queryable
            .Include(p => p.User);
    }
}
