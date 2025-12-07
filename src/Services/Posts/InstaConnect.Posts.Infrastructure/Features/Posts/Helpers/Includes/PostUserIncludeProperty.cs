using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includes;
public class PostUserIncludeProperty : IPostIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostUserIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostIncludeProperty IncludeProperty => PostIncludeProperty.User;

    public IAggregateFluent<Post> Include(IAggregateFluent<Post> pipeline)
    {
        return pipeline
            .IncludeOne(
                _postsContext.Users,
                p => p.UserId,
                u => u.Id,
                p => p.User!
            );
    }
}
