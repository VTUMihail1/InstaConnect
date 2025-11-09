using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includes;
public class PostCommentLikeUserIncludeProperty : IPostCommentLikeIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostCommentLikeUserIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostCommentLikeIncludeProperty IncludeProperty => PostCommentLikeIncludeProperty.User;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> pipeline)
    {
        return pipeline
            .Lookup<PostCommentLike, User, PostCommentLike>(
                _postsContext.Users,
                p => p.UserId,
                u => u.Id,
                p => p.User
            );
    }
}
