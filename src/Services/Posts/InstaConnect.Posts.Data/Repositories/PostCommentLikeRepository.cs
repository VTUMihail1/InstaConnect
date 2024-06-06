using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Repositories;

public class PostCommentLikeRepository : BaseRepository<PostCommentLike>, IPostCommentLikeRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentLikeRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }

    public virtual async Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken)
    {
        var postCommentLike =
        await IncludeProperties(
            _postsContext.PostCommentLikes)
            .FirstOrDefaultAsync(pl => pl.UserId == userId && pl.PostCommentId == postCommentId);

        return postCommentLike;
    }
}
