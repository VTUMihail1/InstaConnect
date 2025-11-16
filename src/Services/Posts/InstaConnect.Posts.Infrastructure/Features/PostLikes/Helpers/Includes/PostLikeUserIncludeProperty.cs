using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includes;
public class PostLikeUserIncludeProperty : IPostLikeIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostLikeUserIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostLikeIncludeProperty IncludeProperty => PostLikeIncludeProperty.User;

    public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> pipeline)
    {
        return pipeline
            .Lookup<PostLike, PostLike, PostLike>(
                _postsContext.PostLikes,
                p => p.Id.UserId,
                u => u.Id,
                p => p.User
            );
    }
}
