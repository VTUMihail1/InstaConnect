using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Repositories;

internal class PostCommentLikeWriteRepository : BaseWriteRepository<PostCommentLike>, IPostCommentLikeWriteRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentLikeWriteRepository(PostsContext postsContext) : base(postsContext)
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
}
