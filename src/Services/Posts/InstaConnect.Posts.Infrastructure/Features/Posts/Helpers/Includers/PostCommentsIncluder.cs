using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class PostCommentsIncluder : IPostIncluder
{
    private readonly IPostsContext _context;

    public PostCommentsIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Posts;

    public PostsIncludeType IncludeType => PostsIncludeType.PostComments;

    public IAggregateFluent<Post> Include(IAggregateFluent<Post> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.PostComments,
                p => p.Id,
                c => c.Id.Id,
                p => p.PostComments
            );
    }
}
