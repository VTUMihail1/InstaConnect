using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Repositories;

internal class PostCommentLikeReadRepository : BaseReadRepository<PostCommentLike>, IPostCommentLikeReadRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentLikeReadRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }

    public virtual async Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken)
    {
        var postCommentLike =
        await IncludeProperties(
            _postsContext.PostCommentLikes)
            .FirstOrDefaultAsync(pl => pl.UserId == userId && pl.PostCommentId == postCommentId, cancellationToken);

        return postCommentLike;
    }

    protected override IQueryable<PostCommentLike> IncludeProperties(IQueryable<PostCommentLike> queryable)
    {
        return queryable
            .Include(p => p.User);
    }
}
