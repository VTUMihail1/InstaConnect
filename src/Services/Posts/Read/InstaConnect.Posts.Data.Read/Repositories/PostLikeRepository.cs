using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Read.Repositories;

public class PostLikeRepository : BaseRepository<PostLike>, IPostLikeRepository
{
    private readonly PostsContext _postsContext;

    public PostLikeRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }

    public virtual async Task<PostLike?> GetByUserIdAndPostIdAsync(string userId, string postId, CancellationToken cancellationToken)
    {
        var postLike =
        await IncludeProperties(
            _postsContext.PostLikes)
            .FirstOrDefaultAsync(pl => pl.UserId == userId && pl.PostId == postId);

        return postLike;
    }
}
