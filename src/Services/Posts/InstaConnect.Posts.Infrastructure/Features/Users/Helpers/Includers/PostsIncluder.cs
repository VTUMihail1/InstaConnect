using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class PostsIncluder : IUserIncluder
{
    private readonly IPostsContext _context;

    public PostsIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.User;

    public PostsIncludeType IncludeType => PostsIncludeType.Post;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.Posts,
                p => p.Id,
                l => l.UserId,
                p => p.Posts
            );
    }
}
