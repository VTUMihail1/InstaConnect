using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includes;

public class UserPostLikesIncludeProperty : IUserIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public UserPostLikesIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.PostLikes;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .IncludeMany(
                _postsContext.PostLikes,
                p => p.Id,
                l => l.Id.UserId,
                p => p.PostLikes
            );
    }
}
