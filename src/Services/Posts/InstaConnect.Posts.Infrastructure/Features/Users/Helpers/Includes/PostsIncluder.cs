using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includes;

internal class PostsIncluder : IUserIncluder
{
    private readonly IPostsContext _postsContext;

    public PostsIncluder(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Users;

    public PostsIncludeType IncludeType => PostsIncludeType.Posts;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _postsContext.Posts,
                p => p.Id,
                l => l.UserId,
                p => p.Posts
            );
    }
}
