using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includes;

public class PostCommentLikesIncludeProperty : IPostCommentIncludeProperty
{
    private readonly IPostsContext _postsContext;

    public PostCommentLikesIncludeProperty(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostCommentIncludeProperty IncludeProperty => PostCommentIncludeProperty.Likes;

    public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> pipeline)
    {
        return pipeline
            .Lookup<PostComment, PostCommentLike, PostComment>(
                _postsContext.PostCommentLikes,
                p => p.Id,
                u => u.Id.CommentId,
                p => p.Likes
            );
    }
}
