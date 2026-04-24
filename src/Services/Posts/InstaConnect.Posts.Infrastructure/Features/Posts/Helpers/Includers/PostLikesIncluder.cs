using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class PostLikesIncluder : IPostIncluder
{
    private readonly IPostsContext _context;

    public PostLikesIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Post;

    public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

    public IAggregateFluent<Post> Include(IAggregateFluent<Post> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.PostLikes,
                p => p.Id,
                l => l.Id.Id,
                p => p.PostLikes
            );
    }
}
