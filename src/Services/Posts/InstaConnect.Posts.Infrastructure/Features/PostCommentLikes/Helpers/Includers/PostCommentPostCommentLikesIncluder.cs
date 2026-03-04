using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostCommentLikesIncluder : IPostCommentLikeIncluder
{
    private readonly IPostsContext _context;

    public PostCommentPostCommentLikesIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

    public PostsIncludeType IncludeType => PostsIncludeType.PostCommentLike;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.PostCommentLikes,
                p => p.PostComment!.Id,
                l => l.Id.CommentId,
                p => p.PostComment!.PostCommentLikes
            );
    }
}
