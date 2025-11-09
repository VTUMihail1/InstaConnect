using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includes;

public class PostCommentsIncludeProperty : IPostIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostCommentsIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostIncludeProperty IncludeProperty => PostIncludeProperty.Comments;

    public IAggregateFluent<Post> Include(IAggregateFluent<Post> pipeline)
    {
        return pipeline
            .Lookup<Post, PostComment, Post>(
                _postsContext.PostComments,
                p => p.Id,
                c => c.Id,
                p => p.Comments
            );
    }
}
