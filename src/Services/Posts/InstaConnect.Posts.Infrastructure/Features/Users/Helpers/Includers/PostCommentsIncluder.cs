using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class PostCommentsIncluder : IUserIncluder
{
    private readonly IPostsContext _context;

    public PostCommentsIncluder(IPostsContext context)
    {
        _context = context;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Users;

    public PostsIncludeType IncludeType => PostsIncludeType.PostComments;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.PostComments,
                p => p.Id,
                l => l.UserId,
                p => p.PostComments
            );
    }
}
