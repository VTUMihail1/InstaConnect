using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includes;

public class UserPostCommentsIncludeProperty : IUserIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public UserPostCommentsIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.PostComments;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .IncludeMany(
                _postsContext.PostComments,
                p => p.Id,
                l => l.UserId,
                p => p.PostComments
            );
    }
}
