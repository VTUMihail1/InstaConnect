using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includes;

public class UserPostsIncludeProperty : IUserIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public UserPostsIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.Posts;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .IncludeMany(
                _postsContext.Posts,
                p => p.Id,
                l => l.UserId,
                p => p.Posts
            );
    }
}
