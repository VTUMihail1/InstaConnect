using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostPostLikesIncluder : IPostCommentLikeIncluder
{
    private readonly IPostsContext _context;

    public PostCommentPostPostLikesIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Post;

    public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

    public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.PostLikes,
                p => p.PostComment!.Post!.Id,
                l => l.Id.Id,
                p => p.PostComment!.Post!.PostLikes
            );
    }
}
