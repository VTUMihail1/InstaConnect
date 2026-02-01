using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostCommentLikesIncluder : IPostCommentIncluder
{
    private readonly IPostsContext _context;

    public PostCommentLikesIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostComments;

    public PostsIncludeType IncludeType => PostsIncludeType.PostCommentLikes;

    public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.PostCommentLikes,
                p => p.Id,
                u => u.Id.CommentId,
                p => p.PostCommentLikes
            );
    }
}
