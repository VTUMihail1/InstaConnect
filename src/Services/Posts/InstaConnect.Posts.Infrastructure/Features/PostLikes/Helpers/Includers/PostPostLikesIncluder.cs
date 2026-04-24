using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostPostLikesIncluder : IPostLikeIncluder
{
    private readonly IPostsContext _context;

    public PostPostLikesIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Post;

    public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

    public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.PostLikes,
                p => p.Post!.Id,
                l => l.Id.Id,
                p => p.Post!.PostLikes
            );
    }
}
