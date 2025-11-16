using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includes;
public class PostCommentUserIncludeProperty : IPostCommentIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostCommentUserIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostCommentIncludeProperty IncludeProperty => PostCommentIncludeProperty.User;

    public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> pipeline)
    {
        return pipeline
            .Lookup<PostComment, User, PostComment>(
                _postsContext.Users,
                p => p.UserId,
                u => u.Id,
                p => p.User
            );
    }
}
