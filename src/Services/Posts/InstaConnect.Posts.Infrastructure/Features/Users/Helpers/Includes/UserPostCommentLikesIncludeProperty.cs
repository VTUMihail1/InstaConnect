using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includes;

public class UserPostCommentLikesIncludeProperty : IUserIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public UserPostCommentLikesIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.PostCommentLikes;

    public IAggregateFluent<User> Include(IAggregateFluent<User> pipeline)
    {
        return pipeline
            .IncludeMany(
                _postsContext.PostCommentLikes,
                p => p.Id,
                l => l.Id.UserId,
                p => p.PostCommentLikes
            );
    }
}
