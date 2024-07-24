using InstaConnect.Posts.Read.Data;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Write.Data.Repositories;

internal class PostLikeWriteRepository : BaseWriteRepository<PostLike>, IPostLikeWriteRepository
{
    private readonly PostsContext _postsContext;

    public PostLikeWriteRepository(PostsContext postsContext) : base(postsContext)
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
}
