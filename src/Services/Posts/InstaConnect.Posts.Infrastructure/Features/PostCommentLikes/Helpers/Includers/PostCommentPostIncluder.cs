using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostIncluder : IPostCommentLikeIncluder
{
    private readonly IPostsContext _context;

    public PostCommentPostIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostComments;

    public PostsIncludeType IncludeType => PostsIncludeType.Posts;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Posts,
                pcl => pcl.Id.CommentId.Id,
                p => p.Id,
                pcl => pcl.PostComment!.Post!
            );
    }
}
