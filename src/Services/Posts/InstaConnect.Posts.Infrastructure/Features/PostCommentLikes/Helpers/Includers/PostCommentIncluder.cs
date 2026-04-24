using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentIncluder : IPostCommentLikeIncluder
{
    private readonly IPostsContext _context;

    public PostCommentIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostCommentLike;

    public PostsIncludeType IncludeType => PostsIncludeType.PostComment;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.PostComments,
                pcl => pcl.Id.CommentId,
                pc => pc.Id,
                pcl => pcl.PostComment!
            );
    }
}
