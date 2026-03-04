using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostIncluder : IPostLikeIncluder
{
    private readonly IPostsContext _context;

    public PostIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.PostLike;

    public PostsIncludeType IncludeType => PostsIncludeType.Post;

    public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Posts,
                pc => pc.Id.Id,
                p => p.Id,
                pc => pc.Post!
            );
    }
}
