using InstaConnect.Posts.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includes;

internal class PostLikesIncluder : IUserIncluder
{
    private readonly IPostsContext _postsContext;

    public PostLikesIncluder(IPostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public PostsDestinationType DestinationType => PostsDestinationType.Users;

    public PostsIncludeType IncludeType => PostsIncludeType.PostLikes;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _postsContext.PostLikes,
                p => p.Id,
                l => l.Id.UserId,
                p => p.PostLikes
            );
    }
}
