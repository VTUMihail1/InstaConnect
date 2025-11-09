using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includes;

public class PostLikesIncludeProperty : IPostIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostLikesIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostIncludeProperty IncludeProperty => PostIncludeProperty.Likes;

    public IAggregateFluent<Post> Include(IAggregateFluent<Post> pipeline)
    {
        return pipeline
            .Lookup<Post, PostLike, Post>(
                _postsContext.PostLikes,
                p => p.Id,
                l => l.Id,
                p => p.Likes
            );
    }
}
